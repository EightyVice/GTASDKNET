using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace GTASDK.ViceCity
{

    public class CPhysical : CEntity
    {
        public CPhysical(IntPtr Address) :base(Address)
        {

        }

        public float TotalSpeed
        {
            get => Memory.ReadFloat(BaseAddress + 0x100);
            //get => (BaseAddress + 0x100).ReadFloat();
        }

    }
    [StructLayout(LayoutKind.Sequential)]
    public class _CPhysical : CEntity._CEntity
    {
        public uint AudioEntityID;
        public float UnknownX;
        public float UnknownY;
        public CVector MoveSpeed;
        public CVector TurnSpeed;
        public CVector vecForce;
        public CVector vecTorque;
        public float Mass;
        public float TurnMass;
        public float VelocityFrequency;
        public float AirResistance;
        public float Elasticity;
        public float BuoyancyConstant;
        public CVector CentreOfMass;
        //public //CEntryInfoList collisionList;
        public IntPtr CPtrNode_MovingListNode;
        public byte uCollideExtra;
        public byte uCollideInfo;
        public byte nNumCollisionRecords;
        public byte field_E7;
        public IntPtr CEntity_CollisionRecords_6;
        public float fTotSpeed;
        public float fCollisionPower;
        public IntPtr CPhysical_PhysColliding;
        public CVector vecCollisionPower;
        public short wComponentCol;
        public byte nMoveFlags;
        public byte nCollFlags;
        public byte nLastCollType;
        public byte nZoneLevel;
        public byte field_11E;
        public byte field_11D;
    }
}
