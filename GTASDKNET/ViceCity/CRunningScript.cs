using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK.ViceCity
{
    public class CRunningScript
    {
        public int BaseAddress;

        public CRunningScript(IntPtr Address) => BaseAddress = Address.ToInt32();

        public CRunningScript Next => new CRunningScript((IntPtr)Memory.ReadInt32(BaseAddress + 0x0));
        public CRunningScript Previous => new CRunningScript((IntPtr)Memory.ReadInt32(BaseAddress + 0x4));


        public string Name
        {
            get => Memory.ReadString(BaseAddress + 0x8, 7);
            set => Memory.WriteString(BaseAddress + 0x8, value);
        }

        public int IP
        {
            get => Memory.ReadInt32(BaseAddress + 0x10);
            set => Memory.WriteInt32(BaseAddress + 0x10, value);
        }

        public bool IsActive
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.Read1bBool(BaseAddress + 0x0078);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.Write1bBool(BaseAddress + 0x0078, value);
        }
        public bool CondResult
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.Read1bBool(BaseAddress + 0x0079);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.Write1bBool(BaseAddress + 0x0079, value);
        }
        public bool UseMissionCleanup
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.Read1bBool(BaseAddress + 0x007A);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.Write1bBool(BaseAddress + 0x007A, value);
        }
        public bool Awake
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.Read1bBool(BaseAddress + 0x007B);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.Write1bBool(BaseAddress + 0x007B, value);
        }
        public int WakeTime
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadInt32(BaseAddress + 0x007C);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteInt32(BaseAddress + 0x007C, value);
        }
        public short LogicalOp
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadInt16(BaseAddress + 0x0080);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteInt16(BaseAddress + 0x0080, value);
        }
        public bool NotFlag
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.Read1bBool(BaseAddress + 0x0082);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.Write1bBool(BaseAddress + 0x0082, value);
        }
        public bool WastedBustedCheck
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.Read1bBool(BaseAddress + 0x0083);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.Write1bBool(BaseAddress + 0x0083, value);
        }
        public bool WastedOrBusted
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.Read1bBool(BaseAddress + 0x0084);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.Write1bBool(BaseAddress + 0x0084, value);
        }
        public bool IsMission
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.Read1bBool(BaseAddress + 0x0085);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.Write1bBool(BaseAddress + 0x0085, value);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void _PorcessOneCommand(IntPtr _this);
        public void ProcessOneCommand()
        {
            Memory.CallFunction<_PorcessOneCommand>(0x44FBE0)((IntPtr)BaseAddress);
        }
    }
}
