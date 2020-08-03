using System;
using System.Runtime.CompilerServices;

namespace GTASDK.ViceCity
{
    public partial class CEntity
    {
        /// <summary>Size of this type in native code, in bytes.</summary>
        public const uint _Size = 0x64U;

        internal IntPtr _vtable
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (IntPtr)(BaseAddress + 0x0);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteInt32(BaseAddress + 0x0, (int)value);
        }

        // CPlaceable at offset 0x4
        public CPlaceable Placement
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new CPlaceable(BaseAddress + 0x4);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => throw new InvalidOperationException("NOT DONE YET");
        }

        // Beginning of union of [RwObject, RwAtomic, RwClump]
        // PLACEHOLDER: Expose raw IntPtr
        // RwObject at offset 0x4C
        public IntPtr RwObject
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (IntPtr)(BaseAddress + 0x4C);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteInt32(BaseAddress + 0x4C, (int)value);
        }
        // PLACEHOLDER: Expose raw IntPtr
        // RpAtomic at offset 0x4C
        public IntPtr RwAtomic
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (IntPtr)(BaseAddress + 0x4C);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteInt32(BaseAddress + 0x4C, (int)value);
        }
        // PLACEHOLDER: Expose raw IntPtr
        // RpClump at offset 0x4C
        public IntPtr RwClump
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (IntPtr)(BaseAddress + 0x4C);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteInt32(BaseAddress + 0x4C, (int)value);
        }
        // End of union

        // Beginning of bitfield unsigned char  Size: 1
        public byte Type
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBitsInt8(BaseAddress + 0x50, 0, 3);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => throw new InvalidOperationException("NOT DONE YET");
        }
        public byte State
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBitsInt8(BaseAddress + 0x50, 3, 5);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => throw new InvalidOperationException("NOT DONE YET");
        }
        // End of bitfield

        // Beginning of bitfield unsigned char  Size: 5
        public bool UseCollision
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x51, 0);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x51, 0, value);
        }
        public bool EntUFlag02
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x51, 1);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x51, 1, value);
        }
        public bool IsStatic
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x51, 2);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x51, 2, value);
        }
        public bool EntUFlag04
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x51, 3);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x51, 3, value);
        }
        public bool EntUFlag05
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x51, 4);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x51, 4, value);
        }
        public bool EntUFlag06
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x51, 5);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x51, 5, value);
        }
        public bool EntUFlag07
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x51, 6);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x51, 6, value);
        }
        public bool RecordCollisions
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x51, 7);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x51, 7, value);
        }
        public bool EntUFlag09
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x52, 0);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x52, 0, value);
        }
        public bool ExplosionProof
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x52, 1);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x52, 1, value);
        }
        public bool IsVisible
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x52, 2);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x52, 2, value);
        }
        public bool HasCollided
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x52, 3);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x52, 3, value);
        }
        public bool RenderScorched
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x52, 4);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x52, 4, value);
        }
        public bool EntUFlag14
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x52, 5);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x52, 5, value);
        }
        public bool UseLevelSectors
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x52, 6);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x52, 6, value);
        }
        public bool IsBigBuilding
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x52, 7);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x52, 7, value);
        }
        public bool EntUFlag17
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x53, 0);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x53, 0, value);
        }
        public bool BulletProof
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x53, 1);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x53, 1, value);
        }
        public bool FireProof
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x53, 2);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x53, 2, value);
        }
        public bool CollisionProof
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x53, 3);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x53, 3, value);
        }
        public bool MeleeProof
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x53, 4);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x53, 4, value);
        }
        public bool ImmuneToNonPlayerDamage
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x53, 5);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x53, 5, value);
        }
        public bool EntUFlag23
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x53, 6);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x53, 6, value);
        }
        public bool RemoveFromWorld
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x53, 7);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x53, 7, value);
        }
        public bool EntUFlag25
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x54, 0);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x54, 0, value);
        }
        public bool ImBeingRendered
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x54, 1);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x54, 1, value);
        }
        public bool EntUFlag27
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x54, 2);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x54, 2, value);
        }
        public bool EntUFlag28
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x54, 3);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x54, 3, value);
        }
        public bool EntUFlag29
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x54, 4);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x54, 4, value);
        }
        public bool EntUFlag30
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x54, 5);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x54, 5, value);
        }
        public bool EntUFlag31
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x54, 6);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x54, 6, value);
        }
        public bool EntUFlag32
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x54, 7);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x54, 7, value);
        }
        public bool EntUFlag33
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x55, 0);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x55, 0, value);
        }
        public bool DontCastShadowsOn
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x55, 1);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x55, 1, value);
        }
        public bool EntUFlag35
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x55, 2);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x55, 2, value);
        }
        public bool IsStaticWaitingForCollision
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x55, 3);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x55, 3, value);
        }
        public bool EntUFlag37
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x55, 4);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x55, 4, value);
        }
        public bool EntUFlag38
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x55, 5);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x55, 5, value);
        }
        public bool EntUFlag39
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x55, 6);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x55, 6, value);
        }
        public bool EntUFlag40
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadBit(BaseAddress + 0x55, 7);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteBit(BaseAddress + 0x55, 7, value);
        }
        // End of bitfield

        private Span<byte> _pad56
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.GetSpan<byte>(BaseAddress + 0x56, 2);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteSpan<byte>(BaseAddress + 0x56, 2, value);
        }

        // short at offset 0x58
        public short ScanCode
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadInt16(BaseAddress + 0x58);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteInt16(BaseAddress + 0x58, value);
        }

        // short at offset 0x5A
        public short RandomSeed
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadInt16(BaseAddress + 0x5A);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteInt16(BaseAddress + 0x5A, value);
        }

        // short at offset 0x5C
        public short ModelIndex
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadInt16(BaseAddress + 0x5C);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteInt16(BaseAddress + 0x5C, value);
        }

        // char at offset 0x5E
        public byte Level
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadByte(BaseAddress + 0x5E);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteByte(BaseAddress + 0x5E, value);
        }

        // unsigned char at offset 0x5F
        public byte Interior
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Memory.ReadByte(BaseAddress + 0x5F);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteByte(BaseAddress + 0x5F, value);
        }

        // PLACEHOLDER: Expose raw IntPtr
        // CReference at offset 0x60
        public IntPtr FirstRef
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (IntPtr)(BaseAddress + 0x60);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Memory.WriteInt32(BaseAddress + 0x60, (int)value);
        }
    }
}