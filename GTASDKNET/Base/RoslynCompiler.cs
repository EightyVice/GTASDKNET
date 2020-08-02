using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.VisualBasic;
using CsLanguageVersion = Microsoft.CodeAnalysis.CSharp.LanguageVersion;
using VbLanguageVersion = Microsoft.CodeAnalysis.VisualBasic.LanguageVersion;
using CsSyntaxFactory = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using VbSyntaxFactory = Microsoft.CodeAnalysis.VisualBasic.SyntaxFactory;

namespace GTASDK.Base
{
    // https://stackoverflow.com/a/32770961
    // https://stackoverflow.com/a/32770484
    class RoslynCompiler
    {
        private static readonly string[] DefaultNamespaces =
        {
            "System",
            "System.IO",
            "System.Net",
            "System.Linq",
            "System.Text",
            "System.Text.RegularExpressions",
            "System.Collections.Generic",
            "System.Threading.Tasks",
            "System.Reflection",
            "System.Windows.Forms"
        };

        private static readonly IEnumerable<MetadataReference> DefaultReferences;

        private static readonly CSharpCompilationOptions CSharpCompilationOptions =
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                .WithOverflowChecks(true)
                .WithOptimizationLevel(OptimizationLevel.Release)
                .WithUsings(DefaultNamespaces);

        private static readonly VisualBasicCompilationOptions VbCompilationOptions =
            new VisualBasicCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                .WithOverflowChecks(true)
                .WithOptimizationLevel(OptimizationLevel.Release);

        static RoslynCompiler()
        {
            var set = new HashSet<string>
            {
                typeof(object).Assembly.Location,
                typeof(PluginsLoader).Assembly.Location
            };

            foreach (var referencedAssembly in typeof(object).Assembly.GetReferencedAssemblies())
            {
                set.Add(Assembly.ReflectionOnlyLoad(referencedAssembly.FullName).Location);
            }

            foreach (var referencedAssembly in typeof(PluginsLoader).Assembly.GetReferencedAssemblies())
            {
                set.Add(Assembly.ReflectionOnlyLoad(referencedAssembly.FullName).Location);
            }

            DefaultReferences = set.Select(e => MetadataReference.CreateFromFile(e)).ToArray();
        }

        private static SyntaxTree ParseCs(string text, string filename = "", CSharpParseOptions options = null)
        {
            var stringText = SourceText.From(text);
            return CsSyntaxFactory.ParseSyntaxTree(stringText, options, filename);
        }

        private static SyntaxTree ParseVb(string text, string filename = "", VisualBasicParseOptions options = null)
        {
            var stringText = SourceText.From(text);
            return VbSyntaxFactory.ParseSyntaxTree(stringText, options, filename);
        }

        public static Assembly CompileCSharpToAssembly(string text, string filename)
        {
            var parsedSyntaxTree = ParseCs(text, filename, CSharpParseOptions.Default.WithLanguageVersion(CsLanguageVersion.CSharp8));

            var compilation = CSharpCompilation.Create(filename + ".dll", new[] { parsedSyntaxTree }, DefaultReferences, CSharpCompilationOptions);

            using (var dllStream = new MemoryStream())
            using (var pdbStream = new MemoryStream())
            {
                var emitResult = compilation.Emit(dllStream, pdbStream);
                if (!emitResult.Success)
                {
                    var errorList = new StringBuilder($"Failed to compile {filename}:").AppendLine();
                    foreach (var diagnostic in emitResult.Diagnostics)
                    {
                        errorList.AppendLine(diagnostic.ToString());
                    }
                    throw new InvalidOperationException(errorList.ToString());
                }

                return Assembly.Load(dllStream.ToArray(), pdbStream.ToArray());
            }
        }

        public static Assembly CompileVbToAssembly(string text, string filename)
        {
            var parsedSyntaxTree = ParseVb(text, filename, VisualBasicParseOptions.Default.WithLanguageVersion(VbLanguageVersion.VisualBasic16));

            var compilation = VisualBasicCompilation.Create(filename + ".dll", new[] { parsedSyntaxTree }, DefaultReferences, VbCompilationOptions);

            using (var dllStream = new MemoryStream())
            using (var pdbStream = new MemoryStream())
            {
                var emitResult = compilation.Emit(dllStream, pdbStream);
                if (!emitResult.Success)
                {
                    var errorList = new StringBuilder($"Failed to compile {filename}:").AppendLine();
                    foreach (var diagnostic in emitResult.Diagnostics)
                    {
                        errorList.AppendLine(diagnostic.ToString());
                    }
                    throw new InvalidOperationException(errorList.ToString());
                }

                return Assembly.Load(dllStream.ToArray(), pdbStream.ToArray());
            }
        }
    }
}
