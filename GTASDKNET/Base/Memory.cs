using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public static unsafe T Get<T>(int pointer)
        {
            return Marshal.PtrToStructure<T>((IntPtr)pointer);
        }

        public static void Set<T>(int pointer, T obj)
        {
            Marshal.StructureToPtr<T>(obj, (IntPtr)pointer, true);
        }
        public static TDelegate CallFunction<TDelegate>(int pointer)
        {
            return Marshal.GetDelegateForFunctionPointer<TDelegate>((IntPtr)pointer);
        }

        public static CVector ReadVector(int pointer)
        {
            unsafe
            {
                return new CVector(*(float*)(pointer),
                                   *(float*)(pointer + 4),
                                   *(float*)(pointer + 8));
            }
        }

        public static void WriteVector(int pointer, CVector vector)
        {
            unsafe
            {
                *(float*)(pointer) = vector.x;
                *(float*)(pointer + 4) = vector.y;
                *(float*)(pointer + 8) = vector.z;
            }

        }

        public static int ReadInt32(int pointer)
        {
            unsafe
            {
                return *(int*)(pointer);
            }
        }
        public static void WriteInt32(int pointer, int value)
        {
            unsafe
            {
                *(int*)(pointer) = value;
            }
        }

        public static short ReadInt16(int pointer)
        {
            unsafe
            {
                return *(short*)(pointer);
            }
        }
        public static void WriteInt16(int pointer, short value)
        {
            unsafe
            {
                *(short*)(pointer) = value;
            }
        }

        public static int ReadByte(int pointer)
        {
            unsafe
            {
                return *(byte*)(pointer);
            }
        }
        public static void WriteByte(int pointer, byte value)
        {
            unsafe
            {
                *(byte*)(pointer) = value;
            }
        }

        public static byte[] ReadByteArray(int pointer, uint size)
        {
            byte[] ret = new byte[size];
            uint x = 0;
            ReadProcessMemory(Process.GetCurrentProcess().Handle, (IntPtr)pointer, ret, size, ref x);
            return ret;
        }
        public static float ReadFloat(int pointer)
        {
            unsafe
            {
                return *(float*)(pointer);
            }
        }
        public static void WriteFloat(int pointer, float value)
        {
            unsafe
            {
                *(float*)(pointer) = value;
            }
        }

        public static bool Read4bBool(int pointer)
        {
            return Convert.ToBoolean(ReadInt32(pointer));
        }

        public static void Write4bBool(int pointer, bool value)
        {
            WriteInt32(pointer, Convert.ToInt32(value));
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
