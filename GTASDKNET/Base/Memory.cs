using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK
{
    public static class Memory
    {
        #region PInvoke
        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory
        (
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            uint nSize,
            ref uint lpNumberOfBytesRead
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory
        (
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            uint nSize,
            out int lpNumberOfBytesWritten
        );
        #endregion

        #region Reading & Writing
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Get<T>(int pointer)
        {
            return Marshal.PtrToStructure<T>((IntPtr)pointer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Set<T>(int pointer, T obj)
        {
            Marshal.StructureToPtr<T>(obj, (IntPtr)pointer, true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TDelegate CallFunction<TDelegate>(int pointer)
        {
            return Marshal.GetDelegateForFunctionPointer<TDelegate>((IntPtr)pointer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe CVector ReadVector(int pointer)
        {
            return new CVector(*(float*)pointer,
                *(float*)(pointer + 4),
                *(float*)(pointer + 8));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void WriteVector(int pointer, CVector vector)
        {
            *(float*)pointer = vector.X;
            *(float*)(pointer + 4) = vector.Y;
            *(float*)(pointer + 8) = vector.Z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void CopyRegion(int target, int source, uint length)
        {
            Buffer.MemoryCopy((void*) source, (void*) target, length, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int ReadInt32(int pointer) => *(int*)pointer;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void WriteInt32(int pointer, int value) => *(int*)pointer = value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe uint ReadUInt32(int pointer) => *(uint*)pointer;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void WriteUInt32(int pointer, uint value) => *(uint*)pointer = value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe short ReadInt16(int pointer) => *(short*)pointer;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void WriteInt16(int pointer, short value) => *(short*)pointer = value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ushort ReadUInt16(int pointer) => *(ushort*)pointer;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void WriteUInt16(int pointer, ushort value) => *(ushort*)pointer = value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe byte ReadByte(int pointer) => *(byte*)pointer;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void WriteByte(int pointer, byte value) => *(byte*)pointer = value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe sbyte ReadSByte(int pointer) => *(sbyte*)pointer;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void WriteSByte(int pointer, sbyte value) => *(sbyte*)pointer = value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe float ReadFloat(int pointer) => *(float*)pointer;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void WriteFloat(int pointer, float value) => *(float*)pointer = value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Read4bBool(int pointer)
        {
            return Convert.ToBoolean(ReadInt32(pointer));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write4bBool(int pointer, bool value)
        {
            WriteInt32(pointer, Convert.ToInt32(value));
        }

        // This is not necessarily a "read" method because changing the memory it points to will change it on the real thing as well.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Span<T> GetSpan<T>(int pointer, int length) where T : unmanaged
        {
            return new Span<T>((void*)pointer, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteSpan<T>(int pointer, int length, Span<T> newSpan) where T : unmanaged
        {
            newSpan.CopyTo(GetSpan<T>(pointer, length));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] ReadByteArray(int pointer, uint size)
        {
            return GetSpan<byte>(pointer, (int)size).ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int ReadBitsInt32(int bytePointer, byte position, int amount)
        {
            var byteValue = *(int*)bytePointer;
            return (byteValue >> position) & (1 << amount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe byte ReadBitsInt8(int bytePointer, byte position, byte amount)
        {
            var byteValue = *(byte*)bytePointer;
            return (byte) ((byteValue >> position) & (1 << amount));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool ReadBit(int bytePointer, byte bitIndex)
        {
            var byteValue = *(byte*)bytePointer;
            return (byteValue & (1 << bitIndex)) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void WriteBit(int bytePointer, byte bitIndex, bool value)
        {
            var existingValue = *(byte*)bytePointer;
            var valueByte = *(byte*)&value; // convert bool to byte, we might as well make it fast :P
            *(byte*)bytePointer = (byte) (existingValue ^ (-valueByte ^ existingValue) & (1 << bitIndex));
        }
        #endregion

        #region Patching
        public static byte[] MakeNop(int pointer, uint size, bool returnOldBytes)
        {
            if (returnOldBytes)
            {
                return ReadByteArray(pointer, size);
            }

            for (int i = 0; i < size; i++)
            {
                WriteByte(pointer + i, 0x90);
            }
            return null;
        }

        #endregion
    }
}
