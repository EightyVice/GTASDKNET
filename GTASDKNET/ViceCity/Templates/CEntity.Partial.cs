using System;

namespace GTASDK.ViceCity
{
    public partial class CEntity
    {
        internal IntPtr _vtable
        {
            get => (IntPtr)(BaseAddress + 0x0);
            set => Memory.WriteInt32(BaseAddress + 0x0, (int)value);
        }

        // CPlaceable at offset 0x4
        public CPlaceable Placement
        {
            get => new CPlaceable(BaseAddress + 0x4);
            set => throw new InvalidOperationException("NOT DONE YET");
        }

        // Beginning of union of [RwObject, RwAtomic, RwClump]
        // PLACEHOLDER: Expose raw IntPtr
        // RwObject at offset 0x4C
        public IntPtr RwObject
        {
            get => (IntPtr)(BaseAddress + 0x4C);
            set => Memory.WriteInt32(BaseAddress + 0x4C, (int)value);
        }
        // PLACEHOLDER: Expose raw IntPtr
        // RpAtomic at offset 0x4C
        public IntPtr RwAtomic
        {
            get => (IntPtr)(BaseAddress + 0x4C);
            set => Memory.WriteInt32(BaseAddress + 0x4C, (int)value);
        }
        // PLACEHOLDER: Expose raw IntPtr
        // RpClump at offset 0x4C
        public IntPtr RwClump
        {
            get => (IntPtr)(BaseAddress + 0x4C);
            set => Memory.WriteInt32(BaseAddress + 0x4C, (int)value);
        }
        // End of union

        // Beginning of bitfield unsigned char  Size: 1
        public byte Type
        {
            get => Memory.ReadBitsInt8(BaseAddress + 0x50, 0, 3);
            set => throw new InvalidOperationException("NOT DONE YET");
        }
        public byte State
        {
            get => Memory.ReadBitsInt8(BaseAddress + 0x50, 3, 5);
            set => throw new InvalidOperationException("NOT DONE YET");
        }
        // End of bitfield

        // Beginning of bitfield unsigned char  Size: 5
        public bool UseCollision
        {
            get => Memory.ReadBit(BaseAddress + 0x51, 0);
            set => Memory.WriteBit(BaseAddress + 0x51, 0, value);
        }
        public bool EntUFlag02
        {
            get => Memory.ReadBit(BaseAddress + 0x51, 1);
            set => Memory.WriteBit(BaseAddress + 0x51, 1, value);
        }
        public bool IsStatic
        {
            get => Memory.ReadBit(BaseAddress + 0x51, 2);
            set => Memory.WriteBit(BaseAddress + 0x51, 2, value);
        }
        public bool EntUFlag04
        {
            get => Memory.ReadBit(BaseAddress + 0x51, 3);
            set => Memory.WriteBit(BaseAddress + 0x51, 3, value);
        }
        public bool EntUFlag05
        {
            get => Memory.ReadBit(BaseAddress + 0x51, 4);
            set => Memory.WriteBit(BaseAddress + 0x51, 4, value);
        }
        public bool EntUFlag06
        {
            get => Memory.ReadBit(BaseAddress + 0x51, 5);
            set => Memory.WriteBit(BaseAddress + 0x51, 5, value);
        }
        public bool EntUFlag07
        {
            get => Memory.ReadBit(BaseAddress + 0x51, 6);
            set => Memory.WriteBit(BaseAddress + 0x51, 6, value);
        }
        public bool RecordCollisions
        {
            get => Memory.ReadBit(BaseAddress + 0x51, 7);
            set => Memory.WriteBit(BaseAddress + 0x51, 7, value);
        }
        public bool EntUFlag09
        {
            get => Memory.ReadBit(BaseAddress + 0x52, 0);
            set => Memory.WriteBit(BaseAddress + 0x52, 0, value);
        }
        public bool ExplosionProof
        {
            get => Memory.ReadBit(BaseAddress + 0x52, 1);
            set => Memory.WriteBit(BaseAddress + 0x52, 1, value);
        }
        public bool IsVisible
        {
            get => Memory.ReadBit(BaseAddress + 0x52, 2);
            set => Memory.WriteBit(BaseAddress + 0x52, 2, value);
        }
        public bool HasCollided
        {
            get => Memory.ReadBit(BaseAddress + 0x52, 3);
            set => Memory.WriteBit(BaseAddress + 0x52, 3, value);
        }
        public bool RenderScorched
        {
            get => Memory.ReadBit(BaseAddress + 0x52, 4);
            set => Memory.WriteBit(BaseAddress + 0x52, 4, value);
        }
        public bool EntUFlag14
        {
            get => Memory.ReadBit(BaseAddress + 0x52, 5);
            set => Memory.WriteBit(BaseAddress + 0x52, 5, value);
        }
        public bool UseLevelSectors
        {
            get => Memory.ReadBit(BaseAddress + 0x52, 6);
            set => Memory.WriteBit(BaseAddress + 0x52, 6, value);
        }
        public bool IsBigBuilding
        {
            get => Memory.ReadBit(BaseAddress + 0x52, 7);
            set => Memory.WriteBit(BaseAddress + 0x52, 7, value);
        }
        public bool EntUFlag17
        {
            get => Memory.ReadBit(BaseAddress + 0x53, 0);
            set => Memory.WriteBit(BaseAddress + 0x53, 0, value);
        }
        public bool BulletProof
        {
            get => Memory.ReadBit(BaseAddress + 0x53, 1);
            set => Memory.WriteBit(BaseAddress + 0x53, 1, value);
        }
        public bool FireProof
        {
            get => Memory.ReadBit(BaseAddress + 0x53, 2);
            set => Memory.WriteBit(BaseAddress + 0x53, 2, value);
        }
        public bool CollisionProof
        {
            get => Memory.ReadBit(BaseAddress + 0x53, 3);
            set => Memory.WriteBit(BaseAddress + 0x53, 3, value);
        }
        public bool MeleeProof
        {
            get => Memory.ReadBit(BaseAddress + 0x53, 4);
            set => Memory.WriteBit(BaseAddress + 0x53, 4, value);
        }
        public bool ImmuneToNonPlayerDamage
        {
            get => Memory.ReadBit(BaseAddress + 0x53, 5);
            set => Memory.WriteBit(BaseAddress + 0x53, 5, value);
        }
        public bool EntUFlag23
        {
            get => Memory.ReadBit(BaseAddress + 0x53, 6);
            set => Memory.WriteBit(BaseAddress + 0x53, 6, value);
        }
        public bool RemoveFromWorld
        {
            get => Memory.ReadBit(BaseAddress + 0x53, 7);
            set => Memory.WriteBit(BaseAddress + 0x53, 7, value);
        }
        public bool EntUFlag25
        {
            get => Memory.ReadBit(BaseAddress + 0x54, 0);
            set => Memory.WriteBit(BaseAddress + 0x54, 0, value);
        }
        public bool ImBeingRendered
        {
            get => Memory.ReadBit(BaseAddress + 0x54, 1);
            set => Memory.WriteBit(BaseAddress + 0x54, 1, value);
        }
        public bool EntUFlag27
        {
            get => Memory.ReadBit(BaseAddress + 0x54, 2);
            set => Memory.WriteBit(BaseAddress + 0x54, 2, value);
        }
        public bool EntUFlag28
        {
            get => Memory.ReadBit(BaseAddress + 0x54, 3);
            set => Memory.WriteBit(BaseAddress + 0x54, 3, value);
        }
        public bool EntUFlag29
        {
            get => Memory.ReadBit(BaseAddress + 0x54, 4);
            set => Memory.WriteBit(BaseAddress + 0x54, 4, value);
        }
        public bool EntUFlag30
        {
            get => Memory.ReadBit(BaseAddress + 0x54, 5);
            set => Memory.WriteBit(BaseAddress + 0x54, 5, value);
        }
        public bool EntUFlag31
        {
            get => Memory.ReadBit(BaseAddress + 0x54, 6);
            set => Memory.WriteBit(BaseAddress + 0x54, 6, value);
        }
        public bool EntUFlag32
        {
            get => Memory.ReadBit(BaseAddress + 0x54, 7);
            set => Memory.WriteBit(BaseAddress + 0x54, 7, value);
        }
        public bool EntUFlag33
        {
            get => Memory.ReadBit(BaseAddress + 0x55, 0);
            set => Memory.WriteBit(BaseAddress + 0x55, 0, value);
        }
        public bool DontCastShadowsOn
        {
            get => Memory.ReadBit(BaseAddress + 0x55, 1);
            set => Memory.WriteBit(BaseAddress + 0x55, 1, value);
        }
        public bool EntUFlag35
        {
            get => Memory.ReadBit(BaseAddress + 0x55, 2);
            set => Memory.WriteBit(BaseAddress + 0x55, 2, value);
        }
        public bool IsStaticWaitingForCollision
        {
            get => Memory.ReadBit(BaseAddress + 0x55, 3);
            set => Memory.WriteBit(BaseAddress + 0x55, 3, value);
        }
        public bool EntUFlag37
        {
            get => Memory.ReadBit(BaseAddress + 0x55, 4);
            set => Memory.WriteBit(BaseAddress + 0x55, 4, value);
        }
        public bool EntUFlag38
        {
            get => Memory.ReadBit(BaseAddress + 0x55, 5);
            set => Memory.WriteBit(BaseAddress + 0x55, 5, value);
        }
        public bool EntUFlag39
        {
            get => Memory.ReadBit(BaseAddress + 0x55, 6);
            set => Memory.WriteBit(BaseAddress + 0x55, 6, value);
        }
        public bool EntUFlag40
        {
            get => Memory.ReadBit(BaseAddress + 0x55, 7);
            set => Memory.WriteBit(BaseAddress + 0x55, 7, value);
        }
        // End of bitfield

        private Span<byte> _pad56
        {
            get => Memory.GetSpan<byte>(BaseAddress + 0x56, 2);
            set => Memory.WriteSpan<byte>(BaseAddress + 0x56, 2, value);
        }

        // short at offset 0x58
        public short ScanCode
        {
            get => Memory.ReadInt16(BaseAddress + 0x58);
            set => Memory.WriteInt16(BaseAddress + 0x58, value);
        }

        // short at offset 0x5A
        public short RandomSeed
        {
            get => Memory.ReadInt16(BaseAddress + 0x5A);
            set => Memory.WriteInt16(BaseAddress + 0x5A, value);
        }

        // short at offset 0x5C
        public short ModelIndex
        {
            get => Memory.ReadInt16(BaseAddress + 0x5C);
            set => Memory.WriteInt16(BaseAddress + 0x5C, value);
        }

        // char at offset 0x5E
        public byte Level
        {
            get => Memory.ReadByte(BaseAddress + 0x5E);
            set => Memory.WriteByte(BaseAddress + 0x5E, value);
        }

        // unsigned char at offset 0x5F
        public byte Interior
        {
            get => Memory.ReadByte(BaseAddress + 0x5F);
            set => Memory.WriteByte(BaseAddress + 0x5F, value);
        }

        // PLACEHOLDER: Expose raw IntPtr
        // CReference at offset 0x60
        public IntPtr FirstRef
        {
            get => (IntPtr)(BaseAddress + 0x60);
            set => Memory.WriteInt32(BaseAddress + 0x60, (int)value);
        }
    }
}