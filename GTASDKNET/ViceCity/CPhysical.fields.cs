using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace GTASDK.ViceCity
{

    public class CPhysical : CEntity
    {
        public const float DefaultGravity = 0.008f;

        public CPhysical(IntPtr address) :base(address)
        {

        }
        public int AudioEntityId
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadInt32(BaseAddress + 0x0064);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteInt32(BaseAddress + 0x0064, value);
        }
        public float fUnknownX
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadFloat(BaseAddress + 0x0068);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteFloat(BaseAddress + 0x0068, value);
        }
        public float fUnknownY
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadFloat(BaseAddress + 0x006C);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteFloat(BaseAddress + 0x006C, value);
        }
        public CVector MoveSpeed
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadVector(BaseAddress + 0x0070);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteVector(BaseAddress + 0x0070, value);
        }
        public CVector TurnSpeed
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadVector(BaseAddress + 0x007C);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteVector(BaseAddress + 0x007C, value);
        }
        public CVector FrictionMoveForce
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadVector(BaseAddress + 0x0088);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteVector(BaseAddress + 0x0088, value);
        }
        public CVector FrictionTurnForce
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadVector(BaseAddress + 0x0094);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteVector(BaseAddress + 0x0094, value);
        }
        public CVector Force
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadVector(BaseAddress + 0x00A0);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteVector(BaseAddress + 0x00A0, value);
        }
        public CVector Torque
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadVector(BaseAddress + 0x00AC);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteVector(BaseAddress + 0x00AC, value);
        }
        public float Mass
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadFloat(BaseAddress + 0x00B8);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteFloat(BaseAddress + 0x00B8, value);
        }
        public float TurnMass
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadFloat(BaseAddress + 0x00BC);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteFloat(BaseAddress + 0x00BC, value);
        }
        public float VelocityFrequency
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadFloat(BaseAddress + 0x00C0);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteFloat(BaseAddress + 0x00C0, value);
        }
        public float AirResistance
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadFloat(BaseAddress + 0x00C4);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteFloat(BaseAddress + 0x00C4, value);
        }
        public float Elasticity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadFloat(BaseAddress + 0x00C8);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteFloat(BaseAddress + 0x00C8, value);
        }
        public float Buoyancy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadFloat(BaseAddress + 0x00CC);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteFloat(BaseAddress + 0x00CC, value);
        }
        public CVector CentreOfMass
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadVector(BaseAddress + 0x00D0);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteVector(BaseAddress + 0x00D0, value);
        }
        public byte CollideInfo
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadByte(BaseAddress + 0x00E0);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteByte(BaseAddress + 0x00E0, value);
        }
        public byte NumCollisionRecords
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadByte(BaseAddress + 0x00EC);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteByte(BaseAddress + 0x00EC, value);
        }
        public byte field_E7
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Memory.ReadByte(BaseAddress + 0x00F8);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => Memory.WriteByte(BaseAddress + 0x00F8, value);
        }

        // CEntity *m_apCollisionRecords[6];

        public float TotalSpeed
        {
            get => Memory.ReadFloat(BaseAddress + 0x100);
            set => Memory.WriteFloat(BaseAddress + 0x100, value);
        }

        public float CollisionPower
        {
            get => Memory.ReadFloat(BaseAddress + 0x104);
            set => Memory.WriteFloat(BaseAddress + 0x104, value);
        }
        // int PhyscColliding;
        public CVector CollisionPowerVector
        {
            get => Memory.ReadVector(BaseAddress + 0x10C);
            set => Memory.WriteVector(BaseAddress + 0x10C, value);
        }

        public short ComponentCollision
        {
            get => Memory.ReadInt16(BaseAddress + 0x118);
            set => Memory.WriteInt16(BaseAddress + 0x118, value);
        }
    }

}
