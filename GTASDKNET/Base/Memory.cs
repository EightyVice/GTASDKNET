using EasyHook;
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
        public static CVector ReadVector(int pointer)
        {
            unsafe
            {
                return new CVector(*(float*)(pointer),
                                   *(float*)(pointer + 4),
                                   *(float*)(pointer + 8));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteVector(int pointer, CVector vector)
        {
            unsafe
            {
                *(float*)(pointer) = vector.X;
                *(float*)(pointer + 4) = vector.Y;
                *(float*)(pointer + 8) = vector.Z;
            }

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ReadInt32(int pointer)
        {
            unsafe
            {
                return *(int*)(pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt32(int pointer, int value)
        {
            unsafe
            {
                *(int*)(pointer) = value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ReadInt16(int pointer)
        {
            unsafe
            {
                return *(short*)(pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt16(int pointer, short value)
        {
            unsafe
            {
                *(short*)(pointer) = value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ReadByte(int pointer)
        {
            unsafe
            {
                return *(byte*)(pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteByte(int pointer, byte value)
        {
            unsafe
            {
                *(byte*)(pointer) = value;
            }
        }

        // This is not necessarily a "read" method because changing the memory it points to will change it on the real thing as well.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> GetSpan<T>(int pointer, int length) where T : unmanaged
        {
            unsafe
            {
                return new Span<T>((void*)pointer, length);
            }
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
        public static float ReadFloat(int pointer)
        {
            unsafe
            {
                return *(float*)(pointer);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteFloat(int pointer, float value)
        {
            unsafe
            {
                *(float*)(pointer) = value;
            }
        }

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
        public static int ReadBitsInt32(int bytePointer, byte position, int amount)
        {
            return (((1 << amount) - 1) & (ReadInt32(bytePointer) >> (position - 1)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ReadBitsInt8(int bytePointer, byte position, int amount)
        {
            return (byte) (((1 << amount) - 1) & (ReadByte(bytePointer) >> (position - 1)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ReadBit(int bytePointer, byte bitIndex)
        {
            return (ReadByte(bytePointer) & (1 << bitIndex)) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteBit(int bytePointer, byte bitIndex, bool value)
        {
            unsafe
            {
                var existingValue = ReadByte(bytePointer);
                var valueByte = *(byte*)(&value); // convert bool to byte, we might as well make it fast :P
                WriteByte(bytePointer, (byte) (existingValue ^ (-valueByte ^ existingValue) & (1 << bitIndex)));
            }
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
            _hook.ThreadACL.SetInclusiveACL(new int[] { Process.GetCurrentProcess().Threads[0].Id });
            return _hook;
        }
        #endregion
    }
}
