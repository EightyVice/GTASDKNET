using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public bool m_bIsActive
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.Read1bBool(BaseAddress + 0x0078);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.Write1bBool(BaseAddress + 0x0078, value);
        }
        public bool m_bCondResult
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.Read1bBool(BaseAddress + 0x0079);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.Write1bBool(BaseAddress + 0x0079, value);
        }
        public bool m_bUseMissionCleanup
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.Read1bBool(BaseAddress + 0x007A);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.Write1bBool(BaseAddress + 0x007A, value);
        }
        public bool m_bAwake
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.Read1bBool(BaseAddress + 0x007B);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.Write1bBool(BaseAddress + 0x007B, value);
        }
        public int m_nWakeTime
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadInt32(BaseAddress + 0x007C);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteInt32(BaseAddress + 0x007C, value);
        }
        public short m_nLogicalOp
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadInt16(BaseAddress + 0x0080);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteInt16(BaseAddress + 0x0080, value);
        }
        public bool m_bNotFlag
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.Read1bBool(BaseAddress + 0x0082);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.Write1bBool(BaseAddress + 0x0082, value);
        }
        public bool m_bWastedBustedCheck
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.Read1bBool(BaseAddress + 0x0083);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.Write1bBool(BaseAddress + 0x0083, value);
        }
        public bool m_bWastedOrBusted
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.Read1bBool(BaseAddress + 0x0084);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.Write1bBool(BaseAddress + 0x0084, value);
        }
        public bool m_bIsMission
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.Read1bBool(BaseAddress + 0x0085);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.Write1bBool(BaseAddress + 0x0085, value);
        }


    }
}
