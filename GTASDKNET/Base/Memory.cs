using EasyHook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GTASDK
{
    public static class Memory
    {
        public delegate void VoidDelegate();

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
        public static TDelegate CallFunction<TDelegate>(int pointer) where TDelegate : Delegate
        {
            return Marshal.GetDelegateForFunctionPointer<TDelegate>((IntPtr)pointer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe TDelegate CallVirtualFunction<TDelegate>(int vtablePointer, uint offset) where TDelegate : Delegate
        {
            var vtable = *(void***)vtablePointer; // a list of function pointers
            var functionOffset = offset * sizeof(int); // offset to the function pointer from the start of the vtable
            return Marshal.GetDelegateForFunctionPointer<TDelegate>((IntPtr)(vtable + functionOffset));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe CVector ReadVector(int pointer) => *(CVector*)pointer;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void WriteVector(int pointer, CVector vector) => *(CVector*)pointer = vector;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void CopyRegion(int target, int source, uint length)
        {
            Buffer.MemoryCopy((void*)source, (void*)target, length, length);
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Read1bBool(int pointer) => Convert.ToBoolean(ReadByte(pointer));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write1bBool(int pointer, bool value) => WriteByte(pointer, Convert.ToByte(value));


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
            List<byte> barr = new List<byte>();
            for (int i = 0; i < size; i++) { barr.Add(ReadByte(pointer + i)); }
            return barr.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteByteArray(int pointer, byte[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                WriteByte(pointer + i, array[i]);
            }
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
            return (byte)((byteValue >> position) & (1 << amount));
        }

        private static byte SetBits8(byte number, byte value, byte startBit, byte endBit)
        {
            //  Create a mask to clear bits i 
            // through j in n. EXAMPLE: i = 2, 
            // j = 4. Result should be 11100011. 
            // For simplicity, we'll use just 8 
            // bits for the example.

            // will equal sequence of all ls 
            const int allOnes = ~0;

            // ls before position j, then 0s.  
            // left = 11100000 
            var left = allOnes << (endBit + 1);

            // l's after position i.  
            // right = 00000011 
            var right = ((1 << startBit) - 1);

            // All ls, except for 0s between i  
            // and j. mask 11100011 
            var mask = left | right;

            // Clear bits j through i then put min there
            // Clear bits j through i. 
            var nCleared = number & mask;

            // Move m into correct position. 
            var mShifted = value << startBit;

            // OR them, and we're done! 
            return (byte)(nCleared | mShifted);
        }

        private static int SetBits32(int number, int value, byte startBit, byte endBit)
        {
            //  Create a mask to clear bits i 
            // through j in n. EXAMPLE: i = 2, 
            // j = 4. Result should be 11100011. 
            // For simplicity, we'll use just 8 
            // bits for the example.

            // will equal sequence of all ls 
            var allOnes = ~0;

            // ls before position j, then 0s.  
            // left = 11100000 
            var left = allOnes << (endBit + 1);

            // l's after position i.  
            // right = 00000011 
            var right = ((1 << startBit) - 1);

            // All ls, except for 0s between i  
            // and j. mask 11100011 
            var mask = left | right;

            // Clear bits j through i then put min there
            // Clear bits j through i. 
            var nCleared = number & mask;

            // Move m into correct position. 
            var mShifted = value << startBit;

            // OR them, and we're done! 
            return nCleared | mShifted;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void WriteBitsInt8(int bytePointer, byte position, byte amount, byte value)
        {
            var existingValue = *(byte*)bytePointer;
            *(byte*)bytePointer = SetBits8(existingValue, value, position, (byte)(position + amount));
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
            *(byte*)bytePointer = (byte)(existingValue ^ (-valueByte ^ existingValue) & (1 << bitIndex));
        }
        // Length without Null terminator
        public static string ReadString(int pointer, uint length)
        {
            return Encoding.ASCII.GetString(ReadByteArray(pointer, length + 1));
        }

        public static void WriteString(int pointer, string value)
        {
            var bytearr = Encoding.ASCII.GetBytes(value);
            WriteByteArray(pointer, bytearr);
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

        #region Hooking
        public static LocalHook Hook(IntPtr Address, Delegate functionDelegate)
        {
            var _hook = LocalHook.Create(Address, functionDelegate, null);
            _hook.ThreadACL.SetExclusiveACL(new int[] { 0 });
            return _hook;
        }
        #endregion
    }
}