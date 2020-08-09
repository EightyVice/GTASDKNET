using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using GTASDK.Base;
using System.Threading;

namespace GTASDK
{
    internal class PluginsLoader
    {
        public IList<Assembly> Assemblies = new List<Assembly>();
        public IReadOnlyList<Type> Classes;

        private readonly string _pluginDirectory;
        private readonly string[] _cmdLine;

        public PluginsLoader(string directory, string[] commandLine)
        {
            _pluginDirectory = directory;
            _cmdLine = commandLine;
        }

        public void LoadPluginAssemblies()
        {
            try
            {
                Parallel.ForEach(Directory.GetFiles(_pluginDirectory), file =>
                {
                    switch (Path.GetExtension(file))
                    {
                        case ".dll" when file.EndsWith(".net.dll"):
                            Assemblies.Add(Assembly.LoadFrom(file));
                            break;
                        case ".cs":
                            Assemblies.Add(RoslynCompiler.CompileCSharpToAssembly(File.ReadAllText(file), file));
                            break;
                        case ".vb":
                            Assemblies.Add(RoslynCompiler.CompileVbToAssembly(File.ReadAllText(file), file));
                            break;
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errored during assembly loading or compilation:\n" + ex, "GTASDK.NET", MessageBoxButtons.OK);
                Debugger.Break();
                Environment.Exit(1);
            }
        }

        public void InitAllScripts()
        {
            var classes =
                from asm in Assemblies
                from cls in asm.GetTypes()
                where cls.BaseType == typeof(Plugin)
                select cls;
            Classes = classes.ToArray();

            foreach (var plugin in Classes)
            {
                // Search for all constructors in the script.
                foreach (var ctor in plugin.GetConstructors())
                {
                    // Get all the parameters defined in the constructor
                    var param = ctor.GetParameters();
                    // If the constructor meets our requirements
                    if (param.Length == 1 && param[0].ParameterType == typeof(string[]))
                    {
                        Thread thread = new Thread(() =>
                        {
                            ctor.Invoke(new object[] { _cmdLine });
                        });
                        thread.Start();
                    }
                }
            }
        }

    }
}
