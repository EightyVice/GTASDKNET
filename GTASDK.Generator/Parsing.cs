using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK.Generator
{
    internal static class Parsing
    {
        public static Field ParseComplexField(Dictionary<object, object> dict)
        {
            var entryKvp = dict.Single();
            var instruction = (string)entryKvp.Key;
            var data = (List<object>)entryKvp.Value;
            switch (instruction)
            {
                case "union":
                    return ParseUnion(data);
                case "bitfield":
                    return ParseBitfield(data);
                default:
                    throw new ArgumentException($"Invalid instruction {instruction}, must be one of [union, bitfield]");
            }
        }

        public static Field ParseBitfield(List<object> data)
        {
            // Type of the bitfield members
            string type = null;
            var bitfieldBits = new List<(string name, uint length)>();

            foreach (var dataEntry in data)
            {
                switch (dataEntry)
                {
                    case Dictionary<object, object> dict1:
                        foreach (var kvp1 in dict1)
                        {
                            switch ((string)kvp1.Key)
                            {
                                case "type":
                                    type = (string)kvp1.Value;
                                    break;
                                default:
                                    throw new ArgumentException(
                                        $"Unsupported bitfield parameter {kvp1.Key}, must be one of [name, type]");
                            }
                        }

                        break;
                    case List<object> list1:
                        if (list1.Count != 2)
                        {
                            throw new ArgumentException(
                                $"Bitfield entry must be a tuple of [name, bitLength], but had too many or too few elements: {string.Join(",", list1)}");
                        }

                        bitfieldBits.Add(((string)list1[0], (uint)(int)list1[1]));
                        break;
                    default:
                        throw new ArgumentException($"Unrecognized bitfield entry type {dataEntry}");
                }
            }

            if (type == null)
            {
                throw new ArgumentNullException(nameof(type), "A bitfield must have a type specified");
            }

            return new BitfieldField(type, bitfieldBits);
        }

        public static Field ParseUnion(IEnumerable<object> data)
        {
            var unionElements = new List<AlignedField>();
            foreach (List<object> unionElement in data)
            {
                if (unionElement.Count != 2)
                {
                    throw new ArgumentException(
                        $"Union must be a tuple of [type, name], but had too many or too few elements: {string.Join(",", unionElement)}");
                }

                unionElements.Add(new AlignedField((string)unionElement[0], (string)unionElement[1]));
            }

            return new UnionField(unionElements);
        }

        public static Field ParseRegularField(IReadOnlyList<object> list)
        {
            return list.Count == 3
                ? new AlignedField((string)list[1], (string)list[2], (string)list[0] == "private" ? Visibility.@private : Visibility.@public)
                : new AlignedField((string)list[0], (string)list[1]);
        }

        public static Field ParseStringDescriptor(string str)
        {
            if (str == "vtable")
            {
                return new VTableField();
            }

            throw new ArgumentException($"Unrecognized string {str}");
        }
    }

    internal abstract class Field
    {
        public abstract uint Size { get; }
        public virtual string Name { get; protected set; }
        public virtual Visibility Visibility { get; protected set; } = Visibility.@public;

        public abstract string Emit(uint offset);
    }

    internal sealed class VTableField : Field
    {
        public override uint Size { get; } = Program.Pointer.Size;
        public override string Name => "_vtable";
        public override Visibility Visibility => Visibility.@internal;
        public override string Emit(uint offset)
        {
            return $@"
                {Visibility} IntPtr {Name}
                {{
                    get => {Program.Pointer.Template.Get($"BaseAddress + 0x{offset:X}")};
                    set => {Program.Pointer.Template.Set($"BaseAddress + 0x{offset:X}")};
                }}
            ";
        }
    }

    internal abstract class TypedField : Field
    {
        public string Type { get; }
        public bool IsPointer { get; }
        public uint? InlineArrayLength { get; }

        protected TypedField(string type)
        {
            if (type.EndsWith("*"))
            {
                type = type.Substring(0, type.Length - 1);
                IsPointer = true;
            }

            if (type.EndsWith("]"))
            {
                var sizeStartingIndex = type.IndexOf('[') + 1;
                var sizeEndIndex = type.Length - 1;
                InlineArrayLength = uint.Parse(type.Substring(sizeStartingIndex, sizeEndIndex - sizeStartingIndex));
                type = type.Substring(0, sizeStartingIndex - 1);
            }

            Type = type;
        }
    }

    internal sealed class AlignedField : TypedField
    {
        public override uint Size => BaseSize * (InlineArrayLength ?? 1);
        private uint BaseSize => IsPointer ? Program.Pointer.Size : Program.Types[Type].Size;

        public AlignedField(string type, string name, Visibility visibility = Visibility.@public) : base(type)
        {
            Name = name;
            Visibility = visibility;
        }
        public override string Emit(uint offset)
        {
            if (InlineArrayLength.HasValue)
            {
                // TODO: do we need to support both InlineArrayLength and IsPointer at the same time?

                return $@"
                    {Visibility} Span<{Program.Types[Type].TypeMapsTo ?? Type}> {Name}
                    {{
                        get => Memory.GetSpan<{Program.Types[Type].TypeMapsTo ?? Type}>(BaseAddress + 0x{offset:X}, {InlineArrayLength.Value});
                        set => Memory.WriteSpan<{Program.Types[Type].TypeMapsTo ?? Type}>(BaseAddress + 0x{offset:X}, {InlineArrayLength.Value}, value);
                    }}
                ";
            }

            if (IsPointer)
            {
                if (!Program.Types.TryGetValue(Type, out var type))
                {
                    return $@"
                        // PLACEHOLDER: Expose raw IntPtr
                        // {Type} at offset 0x{offset:X}
                        {Visibility} IntPtr {Name}
                        {{
                            get => {Program.Pointer.Template.Get($"BaseAddress + 0x{offset:X}")};
                            set => {Program.Pointer.Template.Set($"BaseAddress + 0x{offset:X}")};
                        }}
                    ";
                }

                return $@"
                    // {Type} at offset 0x{offset:X}
                    {Visibility} {type.TypeMapsTo ?? Type} {Name}
                    {{
                        get => {type.Template.Get(Program.Pointer.Template.Get($"BaseAddress + 0x{offset:X}"))};
                        set => throw new InvalidOperationException(""NOT DONE YET"");
                    }}
                ";
            }

            return $@"
                // {Type} at offset 0x{offset:X}
                {Visibility} {Program.Types[Type].TypeMapsTo ?? Type} {Name}
                {{
                    get => {Program.Types[Type].Template.Get($"BaseAddress + 0x{offset:X}")};
                    set => {Program.Types[Type].Template.Set($"BaseAddress + 0x{offset:X}")};
                }}
            ";
        }
    }

    internal class UnionField : Field
    {
        public IReadOnlyList<Field> Elements { get; }
        public override uint Size { get; }

        public UnionField(IEnumerable<Field> elements)
        {
            Elements = elements.ToArray();
            Size = Elements.Max(e => e.Size);
        }

        public override string Emit(uint offset)
        {
            var sb = new StringBuilder($"// Beginning of union of [{string.Join(", ", Elements.Select(e => e.Name))}]\n");
            foreach (var element in Elements)
            {
                sb.Append(element.Emit(offset)); // Emit all elements at the same offset
            }
            sb.Append("\n// End of union\n");
            return sb.ToString();
        }
    }

    internal sealed class BitfieldField : Field
    {
        public string Type { get; }
        public IReadOnlyList<(string name, uint length)> BitfieldElements { get; }
        public override uint Size { get; }

        public BitfieldField(string type, IReadOnlyList<(string name, uint length)> bitfieldElements)
        {
            Name = null;
            Type = type;
            BitfieldElements = bitfieldElements;

            var bitCount = bitfieldElements.Aggregate(0U, (acc, next) => acc + next.length); // Count the amount of bits
            bitCount = (uint)(bitCount + (bitCount % 8)); // Round up to the nearest byte
            var byteCount = bitCount / 8; // Convert to bytes
            byteCount += byteCount % Program.Types[type].Size; // round up to align with bitfield size

            Size = Math.Max(byteCount, Program.Types[type].Size); // ensure that the size is at least the size of any element
        }

        public override string Emit(uint offset)
        {
            var sb = new StringBuilder($"// Beginning of bitfield {Type} {Name} Size: {Size} \n");
            var bitOffset = 0U;
            foreach (var (name, length) in BitfieldElements)
            {
                if (length == 1)
                {
                    sb.Append($@"
                        {Visibility} bool {name}
                        {{
                            get => Memory.ReadBit(BaseAddress + 0x{offset:X}, {bitOffset});
                            set => Memory.WriteBit(BaseAddress + 0x{offset:X}, {bitOffset}, value);
                        }}
                    ");
                }
                else
                {
                    sb.Append($@"
                        {Visibility} {Program.Types[Type].TypeMapsTo ?? Type} {name}
                        {{
                            get => {Program.Types[Type].BitsTemplate.Get($"BaseAddress + 0x{offset:X}", bitOffset, length)};
                            set => {Program.Types[Type].BitsTemplate.Set($"BaseAddress + 0x{offset:X}", bitOffset, length)};
                        }}
                    ");
                }

                bitOffset += length;
                if (bitOffset >= 8)
                {
                    offset += bitOffset / 8;
                    bitOffset %= 8;
                }
            }
            sb.Append("\n// End of bitfield\n");
            return sb.ToString();
        }
    }


    internal enum Visibility
    {
        @private, @internal, @public
    }
}
