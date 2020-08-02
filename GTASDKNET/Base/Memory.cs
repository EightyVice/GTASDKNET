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
                *(float*)(pointer) = vector.x;
                *(float*)(pointer + 4) = vector.y;
                *(float*)(pointer + 8) = vector.z;
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
        public static byte[] ReadByteArray(int pointer, int size)
        {
            return GetSpan<byte>(pointer, size).ToArray();
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




        public static T Read<T>(int address)
        {
            Type t = typeof(T);
            if(t == typeof(int))
            {
                return (T)Convert.ChangeType(BitConverter.ToInt32(Read(new IntPtr(address), 4), 0), typeof(int));
            }
            if (t == typeof(short))
            {
                return (T)Convert.ChangeType(BitConverter.ToInt16(Read(new IntPtr(address), 2), 0), typeof(short));
            }
            if (t == typeof(float))
            {
                return (T)Convert.ChangeType(BitConverter.ToSingle(Read(new IntPtr(address), 4), 0), typeof(float));
            }
            if (t == typeof(byte))
            {
                return (T)Convert.ChangeType(BitConverter.ToChar(Read(new IntPtr(address), 1), 0), typeof(byte));
            }
            if (t == typeof(bool))
            {
                return (T)Convert.ChangeType(BitConverter.ToBoolean(Read(new IntPtr(address), 1), 0), typeof(bool));
            }
            return default(T);
        }
        public static T ReadOffset<T>(int Base, int Offset)
        {
            Type t = typeof(T);
            if (t == typeof(int))
            {
                return (T)Convert.ChangeType(BitConverter.ToInt32(Read(new IntPtr(Base + Offset), 4), 0), typeof(int));
            }
            if (t == typeof(short))
            {
                return (T)Convert.ChangeType(BitConverter.ToInt16(Read(new IntPtr(Base + Offset), 2), 0), typeof(short));
            }
            if (t == typeof(float))
            {
                return (T)Convert.ChangeType(BitConverter.ToSingle(Read(new IntPtr(Base + Offset), 4), 0), typeof(float));
            }
            if (t == typeof(byte))
            {
                return (T)Convert.ChangeType(BitConverter.ToChar(Read(new IntPtr(Base + Offset), 1), 0), typeof(byte));
            }
            if (t == typeof(bool))
            {
                return (T)Convert.ChangeType(BitConverter.ToBoolean(Read(new IntPtr(Base + Offset), 1), 0), typeof(bool));
            }
            return default(T);
        }
        public static byte[] Read(IntPtr address, uint size)
        {
            uint bytes = 0;
            var buffer = new byte[size];

            ReadProcessMemory(Process.GetCurrentProcess().Handle, address, buffer, size, ref bytes);

            return buffer;
        }

        #region ViceCity 
            

        //    #region Writing        
        //public static void VCWriteByte(int VC10EnAddress, int VC11EnAddress, int VCSteamAddress)
        //{
        //    //return WriteByte(GameVersion.VCReturnAddressByGameVersion(VC10EnAddress, VC11EnAddress, VCSteamAddress).ToInt32());
        //}
        //public static void VCWriteInt32(int VC10EnAddress, int VC11EnAddress, int VCSteamAddress)
        //{
        //    return ReadInt32(GameVersion.VCReturnAddressByGameVersion(VC10EnAddress, VC11EnAddress, VCSteamAddress).ToInt32());

        //}
        //public static void VCWriteInt16(int VC10EnAddress, int VC11EnAddress, int VCSteamAddress)
        //{
        //    return ReadInt16(GameVersion.VCReturnAddressByGameVersion(VC10EnAddress, VC11EnAddress, VCSteamAddress).ToInt32());

        //}
        //public static void VCWriteFloat(int VC10EnAddress, int VC11EnAddress, int VCSteamAddress)
        //{
        //    return ReadSingle(GameVersion.VCReturnAddressByGameVersion(VC10EnAddress, VC11EnAddress, VCSteamAddress).ToInt32());

        //}
        //public static void VCWrite(uint size, int VC10EnAddress, int VC11EnAddress, int VCSteamAddress)
        //{
        //    return Read(GameVersion.VCReturnAddressByGameVersion(VC10EnAddress, VC11EnAddress, VCSteamAddress), size);
        //}
        //    #endregion
        #endregion

    }
}
