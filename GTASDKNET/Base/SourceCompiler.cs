using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace GTASDK
{
    class SourceCompiler
    {
        public enum Lang
        {
            CSharp,
            VB
        }
        private static readonly string[] DefaultNamespaces =
        {
            "System",
            "System.IO",
            "System.Net",
            "System.Linq",
            "System.Text",
            "System.Text.RegularExpressions",
            "System.Threading.Tasks",
            "System.Reflection",
            "System.Windows.Forms"
        };


        public static Assembly Compile(string fileLocation, Lang Language)
        {
            var compilerParams = new CompilerParameters();
            compilerParams.CompilerOptions = "/optimize";
            compilerParams.GenerateInMemory = true;
            compilerParams.IncludeDebugInformation = true;
            foreach(var reference in DefaultNamespaces) { compilerParams.ReferencedAssemblies.Add(reference);}

            CodeDomProvider compiler = null;
            if(Language == Lang.CSharp) { compiler = new Microsoft.CSharp.CSharpCodeProvider();}
            if(Language == Lang.VB) { compiler = new Microsoft.CSharp.CSharpCodeProvider();}

            CompilerResults compilerResults = compiler.CompileAssemblyFromFile(compilerParams, fileLocation);

            if (!compilerResults.Errors.HasErrors)
            {
                return compilerResults.CompiledAssembly;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach(CompilerError err in compilerResults.Errors)
                {
                    sb.AppendLine(err.ErrorText);
                }
                MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
    }
}
