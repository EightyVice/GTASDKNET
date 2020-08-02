using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using GTASDK.Base;

namespace GTASDK
{
    internal class PluginsLoader
    {
        public IList<Assembly> Assemblies = new List<Assembly>();
        public IList<Type> Classes = new List<Type>();

        private readonly string[] _cmdLine;

        public PluginsLoader(string directory, string[] commandLine)
        {
            _cmdLine = commandLine;
            try
            {
                Parallel.ForEach(Directory.GetFiles(directory), file =>
                {
                    switch (Path.GetExtension(file))
                    {
                        case ".net.dll":
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

            foreach (var script in classes)
            {
                // Search for all constructors in the script.
                foreach (var ctor in script.GetConstructors())
                {
                    // Get all the parameters defined in the constructor
                    var param = ctor.GetParameters();
                    // If the constructor meets our requirements
                    if (param.Length == 1 && param[0].ParameterType == typeof(string[]))
                    {
                        ctor.Invoke(new object[] { _cmdLine });
                    }
                }
            }
        }

    }
}
