using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK.SanAndreas
{
    public partial class CEntity
    {
        public int BaseAddress;
        public CEntity(IntPtr Address) { BaseAddress = Address.ToInt32(); }
        public IntPtr RwObject
        {
            get => (IntPtr)Memory.ReadInt32(BaseAddress + 0x4);
            set => Memory.WriteInt32(BaseAddress + 0x4, value.ToInt32());
        }

        #region BitFields 1

        public bool UsesCollision
        {
            get => Memory.ReadBit(BaseAddress + 0x8, 0);
            set => Memory.WriteBit(BaseAddress + 0x8, 0, value);
        }

        public bool CollisionProcessed
        {
            get => Memory.ReadBit(BaseAddress + 0x8, 1);
            set => Memory.WriteBit(BaseAddress + 0x8, 1, value);
        }

        public bool IsStatic
        {
            get => Memory.ReadBit(BaseAddress + 0x8, 2);
            set => Memory.WriteBit(BaseAddress + 0x8, 2, value);
        }

        public bool HasContacted
        {
            get => Memory.ReadBit(BaseAddress + 0x8, 3);
            set => Memory.WriteBit(BaseAddress + 0x8, 3, value);
        }

        public bool IsStuck
        {
            get => Memory.ReadBit(BaseAddress + 0x8, 4);
            set => Memory.WriteBit(BaseAddress + 0x8, 4, value);
        }

        public bool IsInSafePosition
        {
            get => Memory.ReadBit(BaseAddress + 0x8, 5);
            set => Memory.WriteBit(BaseAddress + 0x8, 5, value);
        }

        public bool WasPostponed
        {
            get => Memory.ReadBit(BaseAddress + 0x8, 6);
            set => Memory.WriteBit(BaseAddress + 0x8, 6, value);
        }

        public bool IsVisible
        {
            get => Memory.ReadBit(BaseAddress + 0x8, 7);
            set => Memory.WriteBit(BaseAddress + 0x8, 7, value);
        }

        #endregion

        #region BitFields 2
        public bool IsBigBuilding
        {
            get => Memory.ReadBit(BaseAddress + 0xC, 0);
            set => Memory.WriteBit(BaseAddress + 0xC, 0, value);
        }

        public bool RenderDamaged
        {
            get => Memory.ReadBit(BaseAddress + 0xC, 1);
            set => Memory.WriteBit(BaseAddress + 0xC, 1, value);
        }

        public bool StreamingDontDelete
        {
            get => Memory.ReadBit(BaseAddress + 0xC, 2);
            set => Memory.WriteBit(BaseAddress + 0xC, 2, value);
        }

        public bool RemoveFromWorld
        {
            get => Memory.ReadBit(BaseAddress + 0xC, 3);
            set => Memory.WriteBit(BaseAddress + 0xC, 3, value);
        }

        public bool HasHitWall
        {
            get => Memory.ReadBit(BaseAddress + 0xC, 4);
            set => Memory.WriteBit(BaseAddress + 0xC, 4, value);
        }

        public bool IsBeingRendered
        {
            get => Memory.ReadBit(BaseAddress + 0xC, 5);
            set => Memory.WriteBit(BaseAddress + 0xC, 5, value);
        }

        public bool DrawLast
        {
            get => Memory.ReadBit(BaseAddress + 0xC, 6);
            set => Memory.WriteBit(BaseAddress + 0xC, 6, value);
        }

        public bool DistanceFade
        {
            get => Memory.ReadBit(BaseAddress + 0xC, 7);
            set => Memory.WriteBit(BaseAddress + 0xC, 7, value);
        }

        #endregion

        #region BitFields 3
        public bool DontCastShadows
        {
            get => Memory.ReadBit(BaseAddress + 0x10, 0);
            set => Memory.WriteBit(BaseAddress + 0x10, 0, value);
        }
        public bool OffScreen
        {
            get => Memory.ReadBit(BaseAddress + 0x10, 1);
            set => Memory.WriteBit(BaseAddress + 0x10, 1, value);
        }

        public bool IsStaticWaitingForCollision
        {
            get => Memory.ReadBit(BaseAddress + 0x10, 2);
            set => Memory.WriteBit(BaseAddress + 0x10, 2, value);
        }

        public bool DontStream
        {
            get => Memory.ReadBit(BaseAddress + 0x10, 3);
            set => Memory.WriteBit(BaseAddress + 0x10, 3, value);
        }

        public bool UnderWater
        {
            get => Memory.ReadBit(BaseAddress + 0x10, 4);
            set => Memory.WriteBit(BaseAddress + 0x10, 4, value);
        }

        public bool HasPreRenderEffects
        {
            get => Memory.ReadBit(BaseAddress + 0x10, 5);
            set => Memory.WriteBit(BaseAddress + 0x10, 5, value);
        }

        public bool IsTempBuilding
        {
            get => Memory.ReadBit(BaseAddress + 0x10, 6);
            set => Memory.WriteBit(BaseAddress + 0x10, 6, value);
        }

        public bool DontUpdateHierarchy
        {
            get => Memory.ReadBit(BaseAddress + 0x10, 7);
            set => Memory.WriteBit(BaseAddress + 0x10, 7, value);
        }
        #endregion

        #region BitFields 4
        public bool HasRoadsignText
        {
            get => Memory.ReadBit(BaseAddress + 0x14, 0);
            set => Memory.WriteBit(BaseAddress + 0x14, 0, value);
        }

        public bool DisplayedSuperLowLOD
        {
            get => Memory.ReadBit(BaseAddress + 0x14, 1);
            set => Memory.WriteBit(BaseAddress + 0x14, 1, value);
        }

        public bool IsProcObject
        {
            get => Memory.ReadBit(BaseAddress + 0x14, 2);
            set => Memory.WriteBit(BaseAddress + 0x14, 2, value);
        }

        public bool BackFaceCulled
        {
            get => Memory.ReadBit(BaseAddress + 0x14, 3);
            set => Memory.WriteBit(BaseAddress + 0x14, 3, value);
        }

        public bool LightObject
        {
            get => Memory.ReadBit(BaseAddress + 0x14, 4);
            set => Memory.WriteBit(BaseAddress + 0x14, 4, value);
        }

        public bool UnImportantStream
        {
            get => Memory.ReadBit(BaseAddress + 0x14, 5);
            set => Memory.WriteBit(BaseAddress + 0x14, 5, value);
        }

        public bool Tunnel
        {
            get => Memory.ReadBit(BaseAddress + 0x14, 6);
            set => Memory.WriteBit(BaseAddress + 0x14, 6, value);
        }

        public bool TunnelTransition
        {
            get => Memory.ReadBit(BaseAddress + 0x14, 7);
            set => Memory.WriteBit(BaseAddress + 0x14, 7, value);
        }
        #endregion

        public short RandomSeed
        {
            get => Memory.ReadInt16(BaseAddress + 0x18);
            set => Memory.WriteInt16(BaseAddress + 0x10, value);
        }

        public short ModelIndex
        {
            get => Memory.ReadInt16(BaseAddress + 0x1C);
            set => Memory.WriteInt16(BaseAddress + 0x1C, value);
        }

        // CReference *m_pReferences;

        // void *m_pStreamingLink;

        public short ScanCode
        {
            get => Memory.ReadInt16(BaseAddress + 0x24);
            set => Memory.WriteInt16(BaseAddress + 0x24, value);
        }

        public byte IPLIndex
        {
            get => Memory.ReadByte(BaseAddress + 0x25);
            set => Memory.WriteByte(BaseAddress + 0x25, value);
        }

        public byte AreaCode
        {
            get => Memory.ReadByte(BaseAddress + 0x26);
            set => Memory.WriteByte(BaseAddress + 0x27, value);
        }

        // TODO...
    }
}
