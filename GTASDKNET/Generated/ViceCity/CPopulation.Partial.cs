using System;
using System.Runtime.CompilerServices;

namespace GTASDK.ViceCity
{
    public partial class CPopulation
    {
        /// <summary>Size of this type in native code, in bytes.</summary>
        public const uint _Size = 0x0U;

        // static int at 0x694DC4
        public static int AllRandomPedsThisType
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadInt32(0x694DC4);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteInt32(0x694DC4, value);
        }

        // static unsigned int at 0x694DC8
        public static uint MaxNumberOfPedsInUse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0x694DC8);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0x694DC8, value);
        }

        // static unsigned char at 0xA10AE9
        public static byte CountDownToPedsAtStart
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadByte(0xA10AE9);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteByte(0xA10AE9, value);
        }

        // static unsigned int at 0xA1069C
        public static uint TotalPeds
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0xA1069C);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0xA1069C, value);
        }

        // static unsigned int at 0x97F284
        public static uint TotalCivPeds
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0x97F284);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0x97F284, value);
        }

        // static unsigned int at 0x94DDB8
        public static uint TotalGangPeds
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0x94DDB8);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0x94DDB8, value);
        }

        // static unsigned int at 0xA0FD3C
        public static uint TotalCarPassengerPeds
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0xA0FD3C);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0xA0FD3C, value);
        }

        // static unsigned int at 0x9B5F70
        public static uint TotalMissionPeds
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0x9B5F70);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0x9B5F70, value);
        }

        // static unsigned int at 0x978800
        public static uint NumCivMale
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0x978800);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0x978800, value);
        }

        // static unsigned int at 0x9B5F50
        public static uint NumCivFemale
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0x9B5F50);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0x9B5F50, value);
        }

        // static unsigned int at 0x94DDCC
        public static uint NumCop
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0x94DDCC);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0x94DDCC, value);
        }

        // static unsigned int at 0xA0D1D0
        public static uint NumEmergency
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0xA0D1D0);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0xA0D1D0, value);
        }

        // static unsigned int at 0x9786DC
        public static uint NumGang1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0x9786DC);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0x9786DC, value);
        }

        // static unsigned int at 0x9786D4
        public static uint NumGang2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0x9786D4);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0x9786D4, value);
        }

        // static unsigned int at 0x9786D8
        public static uint NumGang3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0x9786D8);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0x9786D8, value);
        }

        // static unsigned int at 0x978708
        public static uint NumGang4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0x978708);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0x978708, value);
        }

        // static unsigned int at 0x97870C
        public static uint NumGang5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0x97870C);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0x97870C, value);
        }

        // static unsigned int at 0x9786E0
        public static uint NumGang6
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0x9786E0);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0x9786E0, value);
        }

        // static unsigned int at 0x9786E8
        public static uint NumGang7
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0x9786E8);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0x9786E8, value);
        }

        // static unsigned int at 0x9786C8
        public static uint NumGang8
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0x9786C8);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0x9786C8, value);
        }

        // static unsigned int at 0x9786CC
        public static uint NumGang9
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0x9786CC);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0x9786CC, value);
        }

        // static unsigned int at 0x9785F0
        public static uint NumDummy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0x9785F0);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0x9785F0, value);
        }

        // static float at 0x694DC0
        public static float PedDensityMultiplier
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadFloat(0x694DC0);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteFloat(0x694DC0, value);
        }

        // static bool at 0xA10B31
        public static byte ZoneChangeHasHappened
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadByte(0xA10B31);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteByte(0xA10B31, value);
        }

        // static unsigned int at 0x9753FC
        public static uint NumMiamiViceCops
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadUInt32(0x9753FC);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteUInt32(0x9753FC, value);
        }


    }
}