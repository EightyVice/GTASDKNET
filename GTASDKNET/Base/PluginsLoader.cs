using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.CodeDom.Compiler;
using System.Windows.Forms;

namespace GTASDK
{
    class PluginsLoader
    {
        public List<Assembly> Assemblies;
        public List<Type> Classes;

        private string[] _cmdLine;
        public PluginsLoader(string directory, string[] commandLine)
        {

            _cmdLine = commandLine;
            Assemblies = new List<Assembly>();
            foreach (string file in Directory.GetFiles(directory))
            {
                if (file.EndsWith(".net.dll"))
                {
                    Assembly assembly = Assembly.LoadFrom(file);
                    Assemblies.Add(assembly);
                }
                if (file.EndsWith(".cs") || file.EndsWith(".vb"))
                {
                    var compilerParams = new CompilerParameters();
                    compilerParams.CompilerOptions = "/optimize";
                    compilerParams.GenerateInMemory = true;
                    compilerParams.IncludeDebugInformation = true;
                    compilerParams.ReferencedAssemblies.Add("System.dll");
                    compilerParams.ReferencedAssemblies.Add("System.Core.dll");
                    compilerParams.ReferencedAssemblies.Add("System.Drawing.dll");
                    compilerParams.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                    compilerParams.ReferencedAssemblies.Add("System.XML.dll");
                    compilerParams.ReferencedAssemblies.Add("System.XML.Linq.dll");
                    compilerParams.ReferencedAssemblies.Add("VCScriptHook.dll");

                    CodeDomProvider compiler = null;
                    if (file.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
                    {
                        compiler = new Microsoft.CSharp.CSharpCodeProvider();
                        //compilerParams.CompilerOptions += "/unsafe";
                    }
                    if (file.EndsWith(".vb", StringComparison.OrdinalIgnoreCase))
                    {
                        compiler = new Microsoft.VisualBasic.VBCodeProvider();
                    }

                    CompilerResults compilerResults = compiler.CompileAssemblyFromFile(compilerParams, file);
                    if (!compilerResults.Errors.HasErrors)
                    {
                        Assemblies.Add(compilerResults.CompiledAssembly);
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (CompilerError err in compilerResults.Errors)
                        {
                            sb.AppendLine(err.ErrorText);
                        }
                        MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public void InitAllScripts()
        {
            List<Type> Classes = new List<Type>();
            foreach (Assembly asm in Assemblies)
            {
                // Check all classes in the script
                foreach (Type cls in asm.GetTypes())
                {
                    // If the class inherits base
                    if (cls.BaseType == typeof(Plugin))
                    {
                        Classes.Add(cls);
                    }
                }
            }

            foreach (Type script in Classes)
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
