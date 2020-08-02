using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using SharpYaml.Serialization;

namespace GTASDK.Generator
{
    internal class BuiltinType
    {
        public string TypeMapsTo { get; set; }
        public uint Size { get; set; }
        public GetSetTemplate Template { get; set; }
        public GetSetTemplate BitsTemplate { get; set; }
    }

    internal class Program
    {
        public static readonly Dictionary<string, BuiltinType> Types = new Dictionary<string, BuiltinType>
        {
            ["<pointer>"] = new BuiltinType
            {
                Size = 0x4,
                Template = new GetSetTemplate($"(IntPtr)({0})", $"Memory.WriteInt32({0}, (int)value)")
            },
            // Size 1
            ["bool"] = new BuiltinType
            {
                TypeMapsTo = "byte",
                Size = sizeof(byte),
                Template = new GetSetTemplate($"Memory.ReadByte({0})", $"Memory.WriteByte({0}, value)")
            },
            ["char"] = new BuiltinType
            {
                TypeMapsTo = "byte",
                Size = sizeof(sbyte),
                Template = new GetSetTemplate($"Memory.ReadByte({0})", $"Memory.WriteByte({0}, value)")
            },
            ["char8_t"] = new BuiltinType
            {
                TypeMapsTo = "byte",
                Size = sizeof(byte),
                Template = new GetSetTemplate($"Memory.ReadByte({0})", $"Memory.WriteByte({0}, value)")
            },
            ["signed char"] = new BuiltinType
            {
                TypeMapsTo = "sbyte",
                Size = sizeof(byte),
                Template = new GetSetTemplate($"Memory.ReadByte({0})", $"Memory.WriteByte({0}, value)")
            },
            ["unsigned char"] = new BuiltinType
            {
                TypeMapsTo = "byte",
                Size = sizeof(byte),
                Template = new GetSetTemplate($"Memory.ReadByte({0})", $"Memory.WriteByte({0}, value)"),
                BitsTemplate = new GetSetTemplate($@"Memory.ReadBitsInt8({0}, {1}, {2})", $@"throw new InvalidOperationException(""NOT DONE YET"")")
            },
            ["__int8"] = new BuiltinType
            {
                TypeMapsTo = "byte",
                Size = sizeof(byte),
                Template = new GetSetTemplate($"Memory.ReadByte({0})", $"Memory.WriteByte({0}, value)")
            },
            // Size 2
            ["short"] = new BuiltinType
            {
                Size = sizeof(short),
                Template = new GetSetTemplate($"Memory.ReadInt16({0})", $"Memory.WriteInt16({0}, value)")
            },
            ["CPlaceable"] = new BuiltinType
            {
                Size = 0x48,
                Template = new GetSetTemplate($"new CPlaceable({0})", $@"throw new InvalidOperationException(""NOT DONE YET"")")
            }
        };

        public static BuiltinType Pointer => Types["<pointer>"];

        private static void Main(string[] args)
        {
            var dryRun = false;
            string templateDirectory = null;

            foreach (var arg in args)
            {
                switch (arg)
                {
                    case "-d":
                    case "--dryrun":
                        dryRun = true;
                        break;
                    default:
                        if (arg.StartsWith("-"))
                        {
                            throw new ArgumentException($"Unrecognized switch: {arg}", nameof(arg));
                        }
                        else if (templateDirectory != null)
                        {
                            throw new ArgumentException($"Can only set template directory once, attempted to set it to both {templateDirectory} and {arg}", nameof(arg));
                        }
                        else
                        {
                            templateDirectory = arg;
                        }
                        break;
                }
            }

            if (templateDirectory == null)
            {
                throw new ArgumentNullException(nameof(templateDirectory), "You must pass a directory in which to scan for templates!");
            }

            if (!Directory.Exists(templateDirectory))
            {
                throw new ArgumentException($"The directory at {templateDirectory} does not exist or is not a directory", nameof(templateDirectory));
            }

            foreach (var file in Directory.EnumerateFiles(templateDirectory))
            {
                switch (Path.GetExtension(file))
                {
                    case ".yml":
                        var input = File.ReadAllText(file);
                        var type = GetTypeGraph(input);
                        var outputPath = Path.Combine(Path.GetDirectoryName(file) ?? "", $"{Path.GetFileNameWithoutExtension(file)}.Partial.cs");
                        if (dryRun)
                        {
                            Debug.WriteLine($"Writing the following text to {outputPath}, generated from {file}:");
                            Debug.WriteLine(type.GraphToString());
                        }
                        else
                        {
                            File.WriteAllText(outputPath, type.GraphToString());
                        }
                        Debug.WriteLine($"Processed {outputPath}");
                        break;
                }
            }

        }

        private static TypeGraph GetTypeGraph(string input)
        {
            var serializer = new Serializer();
            var structure = serializer.Deserialize<IDictionary<string, object>>(input);

            var typeNamespace = (string) structure["namespace"];
            var typeName = (string) structure["name"];
            var fieldDefinitions = (List<object>) structure["fields"];

            var presetSize = structure["size"] as int?;

            var fields = new List<Field>();

            uint offset = 0;
            foreach (var entry in fieldDefinitions)
            {
                Field entryField;

                switch (entry)
                {
                    case string str:
                        entryField = Parsing.ParseStringDescriptor(str);
                        break;
                    case List<object> list:
                        entryField = Parsing.ParseRegularField(list);
                        break;
                    case Dictionary<object, object> dict:
                        entryField = Parsing.ParseComplexField(dict);
                        break;
                    default:
                        throw new ArgumentException($"Unrecognized entry type {entry}");
                }

                fields.Add(entryField);
                offset += entryField.Size;
            }

            var size = offset;
            if (size != presetSize)
            {
                Debug.WriteLine($"Size of {typeName} has changed from {presetSize} to {size}");
            }

            return new TypeGraph(typeNamespace, typeName, size, fields);
        }
    }

    internal class GetSetTemplate
    {
        public Template Get => parameters => string.Format(_get.Format, parameters);
        public Template Set => parameters => string.Format(_set.Format, parameters);

        private readonly FormattableString _get;
        private readonly FormattableString _set;

        public GetSetTemplate(FormattableString get, FormattableString set)
        {
            _get = get;
            _set = set;
        }
    }

    internal delegate string Template(params object[] parameters);

    internal class TypeGraph
    {
        public string Namespace { get; }
        public string Name { get; }
        public uint Size { get; }
        public IList<Field> Fields { get; }

        public TypeGraph(string typeNamespace, string name, uint size, IList<Field> fields)
        {
            Namespace = typeNamespace;
            Name = name;
            Size = size;
            Fields = fields;
        }

        public string GraphToString()
        {
            return $@"using System;

namespace {Namespace}
{{
    public partial class {Name}
    {{
{FieldsToString(4, 2)}
    }}
}}";
        }

        private string FieldsToString(int indentation, int indentLevel = 0)
        {
            var fieldsEmitted = new List<string>();
            uint offset = 0;

            foreach (var field in Fields)
            {
                fieldsEmitted.Add(field.Emit(offset));
                offset += field.Size;
            }

            var output = new StringBuilder();
            foreach (var s in fieldsEmitted)
            {
                var lines = s.Split('\n').Select(e => e.Trim()).Where(e => !string.IsNullOrEmpty(e));
                foreach (var line in lines)
                {
                    if (line.EndsWith("}"))
                    {
                        indentLevel--;
                    }

                    output.Append(new string(' ', indentation * indentLevel)).AppendLine(line);

                    if (line.EndsWith("{"))
                    {
                        indentLevel++;
                    }
                }

                output.AppendLine();
            }

            return output.ToString().TrimEnd();
        }
    }
}