using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace GTASDK.ViceCity
{
    #region Enums
    public enum PedType
    {
        PLAYER1,
        PLAYER2,
        PLAYER3,
        PLAYER4,
        CIVMALE,
        CIVFEMALE,
        COP,
        GANG1,
        GANG2,
        GANG3,
        GANG4,
        GANG5,
        GANG6,
        GANG7,
        GANG8,
        GANG9,
        EMERGENCY,
        FIREMAN,
        CRIMINAL,
        UNUSED1,
        PROSTITUTE,
        SPECIAL,
        UNUSED2,
        NUM_PEDTYPES
    }

    public enum PedAction
    {
        None = 0,
        Idle = 1,
        LookEntity = 2,
        LookHeading = 3,
        WanderRange = 4,
        WanderPath = 5,
        SeekPos = 6,
        SeekEntity = 7,
        FleePos = 8,
        FleeEntity = 9,
        Pursue = 10,
        FollowPath = 11,
        SniperMode = 12,
        RocketMode = 13,
        Dummy = 14,
        Pause = 15,
        Attack = 16,
        Fight = 17,
        FacePhone = 18,
        MakeCall = 19,
        Chat = 20,
        Mug = 21,
        AimGun = 22,
        AIControl = 23,
        SeekCar = 24,
        SeekBoat = 25,
        FollowRoute = 26,
        CPR = 27,
        Solicit = 28,
        BuyIcecream = 29,
        Investigate = 30,
        StepAway = 31,
        OnFire = 32,
        Sunbathe = 34,
        Flash = 35,
        Jog = 36,
        AnswerMobile = 37,
        UNKNOWN = 38,
        STATES_NO_AI = 39,
        ABSEIL = 40,
        Sit = 41,
        Jump = 42,
        Fall = 43,
        GetUp = 44,
        Stagger = 45,
        DiveAway = 46,
        States = 47,
        EnterTrain = 48,
        ExitTrain = 49,
        ArrestPlayer = 50,
        Driving = 51,
        Passenger = 52,
        TaxiPassenger = 53,
        OpenDoor = 54,
        Die = 56,
        Dead = 57,
        CarJack = 58,
        DragFromCar = 59,
        EnterCar = 60,
        StealCar = 61,
        ExitCar = 62,
        HandsUp = 63,
        Arrested = 64,
        DeployStinger = 65,
    };

    // TODO: the right writing convention
    public enum Objectives
    {
        None,
        WaitOnFoot,
        WaitOnFootForCop,
        FleeOnFootTillSafe,
        GuardSpot,
        GuardArea,
        WaitInCar,
        WaitInCarThenGetOut,
        KillCharOnFoot,
        KILL_CHAR_ANY_MEANS,
        FLEE_CHAR_ON_FOOT_TILL_SAFE,
        FLEE_CHAR_ON_FOOT_ALWAYS,
        GOTO_CHAR_ON_FOOT,
        GOTO_CHAR_ON_FOOT_WALKING,
        HASSLE_CHAR,
        FOLLOW_CHAR_IN_FORMATION,
        LEAVE_CAR,
        ENTER_CAR_AS_PASSENGER,
        ENTER_CAR_AS_DRIVER,
        FOLLOW_CAR_IN_CAR,
        FIRE_AT_OBJECT_FROM_VEHICLE,
        DESTROY_OBJECT,
        DESTROY_CAR,
        GOTO_AREA_ANY_MEANS,
        GOTO_AREA_ON_FOOT,
        RUN_TO_AREA,
        GOTO_AREA_IN_CAR,
        FOLLOW_CAR_ON_FOOT_WITH_OFFSET,
        GUARD_ATTACK,
        SET_LEADER,
        FOLLOW_ROUTE,
        SOLICIT_VEHICLE,
        HAIL_TAXI,
        CATCH_TRAIN,
        BUY_ICE_CREAM,
        STEAL_ANY_CAR,
        STEAL_ANY_MISSION_CAR,
        MUG_CHAR,
        LEAVE_CAR_AND_DIE,
        GOTO_SEAT_ON_FOOT,
        GOTO_ATM_ON_FOOT,
        FLEE_CAR,
        SUN_BATHE,
        GOTO_BUS_STOP_ON_FOOT,
        GOTO_PIZZA_ON_FOOT,
        GOTO_SHELTER_ON_FOOT,
        AIM_GUN_AT,
        WANDER,
        WAIT_ON_FOOT_AT_SHELTER,
        SPRINT_TO_AREA,
        KILL_CHAR_ON_BOAT,
        SOLICIT_FOOT,
        WAIT_ON_FOOT_AT_BUS_STOP,
        GOTO_ICE_CREAM_VAN_ON_FOOT,
        WAIT_ON_FOOT_AT_ICE_CREAM_VAN,
        OBJ_55,
        OBJ_56,
        OBJ_57,
        OBJ_58,
        OBJ_59
    };

    public enum PedFormation
    {
        Undefined,
        Rear,
        RearLeft,
        RearRight,
        FrontLeft,
        FrontRight,
        Left,
        Right,
        Front
    }

    // TODO: the right writing convention
    public enum PedState
    {
        NONE,
        IDLE,
        LOOK_ENTITY,
        LOOK_HEADING,
        WANDER_RANGE,
        WANDER_PATH,
        SEEK_POS,
        SEEK_ENTITY,
        FLEE_POS,
        FLEE_ENTITY,
        PURSUE,
        FOLLOW_PATH,
        SNIPER_MODE,
        ROCKET_MODE,
        DUMMY,
        PAUSE,
        ATTACK,
        FIGHT,
        FACE_PHONE,
        MAKE_CALL,
        CHAT,
        MUG,
        AIM_GUN,
        AI_CONTROL,
        SEEK_CAR,
        SEEK_IN_BOAT,
        FOLLOW_ROUTE,
        CPR,
        SOLICIT,
        BUY_ICECREAM,
        INVESTIGATE,
        STEP_AWAY,
        ON_FIRE,
        SUN_BATHE,
        FLASH,
        JOG,
        ANSWER_MOBILE,
        
        UNKNOWN,
        
        STATES_NO_AI,
        
        ABSEIL,
        SIT,
        JUMP,
        FALL,
        GETUP,
        STAGGER,
        DIVE_AWAY,
        
        STATES_NO_ST,
        ENTER_TRAIN,
        EXIT_TRAIN,
        ARREST_PLAYER,
        
        DRIVING,
        PASSENGER,
        TAXI_PASSENGER,
        OPEN_DOOR,
        DIE,
        DEAD,
        CARJACK,
        DRAG_FROM_CAR,
        ENTER_CAR,
        STEAL_CAR,
        EXIT_CAR,
        HANDS_UP,
        ARRESTED,
        DEPLOY_STINGER
    }

    public enum MoveState
    {
        None,
        Still,
        Walk,
        Jog,
        Run,
        Sprint,
        Thrown
    }

    // TODO: the right writing convention
    public enum WaiteState
    {
        FALSE,
        TRAFFIC_LIGHTS,
        CROSS_ROAD,
        CROSS_ROAD_LOOK,
        LOOK_PED,
        LOOK_SHOP,
        LOOK_ACCIDENT,
        FACEOFF_GANG,
        DOUBLEBACK,
        HITWALL,
        TURN180,
        SURPRISE,
        STUCK,
        LOOK_ABOUT,
        PLAYANIM_DUCK,
        PLAYANIM_COWER,
        PLAYANIM_TAXI,
        PLAYANIM_HANDSUP,
        PLAYANIM_HANDSCOWER,
        PLAYANIM_CHAT,
        FINISH_FLEE,
        SIT_DOWN,
        SIT_DOWN_RVRS,
        SIT_UP,
        SIT_IDLE,
        USE_ATM,
        SUN_BATHE_PRE,
        SUN_BATHE_DOWN,
        SUN_BATHE_IDLE,
        RIOT,
        FAST_FALL,
        BOMBER,
        STRIPPER,
        GROUND_ATTACK,
        LANCESITTING,
        PLAYANIM_HANDSUP_SIMPLE,
    }
    #endregion
    public partial class CPed : CPhysical
    {
        public CPed(IntPtr address): base(address){

        }
        // type: CCollPoly name: polyColliding offset: 0x120 size: 0x28

        public int fCollisionSpeed
        {
            get => Memory.ReadInt32(BaseAddress + 0x148);
            set => Memory.WriteInt32(BaseAddress + 0x148, value);
        }

        // TODO: BitFlags
        public byte bfFlagsA
        {
            get => Memory.ReadByte(BaseAddress + 0x14C);
            set => Memory.WriteByte(BaseAddress + 0x14C, value);
        }
        public byte bfFlagsB
        {
            get => Memory.ReadByte(BaseAddress + 0x14D);
            set => Memory.WriteByte(BaseAddress + 0x14D, value);
        }
        public byte bfFlagsC
        {
            get => Memory.ReadByte(BaseAddress + 0x14E);
            set => Memory.WriteByte(BaseAddress + 0x14E, value);
        }
        public byte bfFlagsD
        {
            get => Memory.ReadByte(BaseAddress + 0x14F);
            set => Memory.WriteByte(BaseAddress + 0x14F, value);
        }
        public byte bfFlagsE
        {
            get => Memory.ReadByte(BaseAddress + 0x150);
            set => Memory.WriteByte(BaseAddress + 0x150, value);
        }
        public byte bfFlagsF
        {
            get => Memory.ReadByte(BaseAddress + 0x151);
            set => Memory.WriteByte(BaseAddress + 0x151, value);
        }
        public byte bfFlagsG
        {
            get => Memory.ReadByte(BaseAddress + 0x152);
            set => Memory.WriteByte(BaseAddress + 0x152, value);
        }
        public byte bfFlagsH
        {
            get => Memory.ReadByte(BaseAddress + 0x153);
            set => Memory.WriteByte(BaseAddress + 0x153, value);
        }
        public byte bfFlagsI
        {
            get => Memory.ReadByte(BaseAddress + 0x154);
            set => Memory.WriteByte(BaseAddress + 0x154, value);
        }
        public byte bfFlagsJ
        {
            get => Memory.ReadByte(BaseAddress + 0x155);
            set => Memory.WriteByte(BaseAddress + 0x155, value);
        }
        public byte bfFlagsK
        {
            get => Memory.ReadByte(BaseAddress + 0x156);
            set => Memory.WriteByte(BaseAddress + 0x156, value);
        }
        public byte bfFlagsL
        {
            get => Memory.ReadByte(BaseAddress + 0x157);
            set => Memory.WriteByte(BaseAddress + 0x157, value);
        }
        public byte bfFlagsM
        {
            get => Memory.ReadByte(BaseAddress + 0x158);
            set => Memory.WriteByte(BaseAddress + 0x158, value);
        }


        public byte GangFlags
        {
            get => Memory.ReadByte(BaseAddress + 0x15C);
            set => Memory.WriteByte(BaseAddress + 0x15C, value);
        }

        public byte CreatedBy
        {
            get => Memory.ReadByte(BaseAddress + 0x160);
            set => Memory.WriteByte(BaseAddress + 0x160, value);
        }
        // type: byte[3] name: __fx015D offset: 0x161 size: 3
        // type: byte[3] name: __fx015D offset: 0x161 size: 3
        public Objectives Objective
        {
            get => (Objectives)Memory.ReadInt32(BaseAddress + 0x164);
            set => Memory.WriteInt32(BaseAddress + 0x164, (int)value);
        }
        public Objectives PreviousObjective
        {
            get => (Objectives)Memory.ReadInt32(BaseAddress + 0x168);
            set => Memory.WriteInt32(BaseAddress + 0x168, (int)value);
        }
        public CEntity ObjectiveEntity
        {
            get => new CEntity((IntPtr)Memory.ReadInt32(BaseAddress + 0x16C));
            set => Memory.WriteInt32(BaseAddress + 0x16C, value.BaseAddress);
        }
        public CVehicle ObjectiveVehicle
        {
            get => new CVehicle((IntPtr)Memory.ReadInt32(BaseAddress + 0x170));
            set => Memory.WriteInt32(BaseAddress + 0x170, value.BaseAddress);
        }
        public CVector ObjectiveVector
        {
            get => Memory.ReadVector(BaseAddress + 0x174);
            set => Memory.WriteVector(BaseAddress + 0x174, value);
        }
        public float fObjectiveAngle
        {
            get => Memory.ReadFloat(BaseAddress + 0x180);
            set => Memory.WriteFloat(BaseAddress + 0x180, value);
        }
        public CPed pGangLeader
        {
            get => new CPed((IntPtr)Memory.ReadInt32(BaseAddress + 0x184));
            set => Memory.WriteInt32(BaseAddress + 0x184, value.BaseAddress);
        }
        public PedFormation PedFormation
        {
            get => (PedFormation)Memory.ReadInt32(BaseAddress + 0x188);
            set => Memory.WriteInt32(BaseAddress + 0x188, (int)value);
        }
        public int FearFlags
        {
            get => Memory.ReadInt32(BaseAddress + 0x18C);
            set => Memory.WriteInt32(BaseAddress + 0x18C, value);
        }
        public CEntity ThreatEntity
        {
            get => new CEntity((IntPtr)Memory.ReadInt32(BaseAddress + 0x190));
            set => Memory.WriteInt32(BaseAddress + 0x190, value.BaseAddress);
        }
        public CVector2D EventOrThreatVector
        {
            get => Memory.ReadVector2D(BaseAddress + 0x194);
            set => Memory.WriteVector2D(BaseAddress + 0x194, value);
        }
        public int EventType
        {
            get => Memory.ReadInt32(BaseAddress + 0x19C);
            set => Memory.WriteInt32(BaseAddress + 0x19C, value);
        }
        public CEntity EventEntity
        {
            get => new CEntity((IntPtr)Memory.ReadInt32(BaseAddress + 0x1A0));
            set => Memory.WriteInt32(BaseAddress + 0x1A0, value.BaseAddress);
        }
        public float AngleToEvent
        {
            get => Memory.ReadFloat(BaseAddress + 0x1A4);
            set => Memory.WriteFloat(BaseAddress + 0x1A4, value);
        }
        // type: AnimBlendFrameData *[18] name: m_apBones offset: 0x1A8 size: 0x48
        // type: AnimBlendFrameData *[18] name: m_apBones offset: 0x1A8 size: 0x48
        // type: AnimBlendFrameData *[18] name: m_apBones offset: 0x1A8 size: 0x48
        //public int pCurWeaponAtomic
        //{
        //    get => Memory.ReadInt32(BaseAddress + 0x1F0);
        //    set => Memory.WriteInt32(BaseAddress + 0x1F0, value);
        //}

        // TODO: AssociatedAnimGroupID
        public int AnimGroupId
        {
            get => Memory.ReadInt32(BaseAddress + 0x1F4);
            set => Memory.WriteInt32(BaseAddress + 0x1F4, value);
        }
        // 	CAnimBlendAssociation *m_pVehicleAnim; offset: 0x1F8
        public CVector2D AnimMoveDelta
        {
            get => Memory.ReadVector2D(BaseAddress + 0x1FC);
            set => Memory.WriteVector2D(BaseAddress + 0x1FC, value);
        }
        public CVector vecOffsetSeek
        {
            get => Memory.ReadVector(BaseAddress + 0x204);
            set => Memory.WriteVector(BaseAddress + 0x204, value);
        }
        // type: CPedIK name: stPedIK offset: 0x210 size: 0x28
        public CVector2D ActionVector
        {
            get => Memory.ReadVector2D(BaseAddress + 0x238);
            set => Memory.WriteVector2D(BaseAddress + 0x238, value);
        }

        public int ActionTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x240);
            set => Memory.WriteInt32(BaseAddress + 0x240, value);
        }
        public PedState PedState
        {
            get => (PedState)Memory.ReadInt32(BaseAddress + 0x244);
            set => Memory.WriteInt32(BaseAddress + 0x244, (int)value);
        }
        public PedState LastAction
        {
            get => (PedState)Memory.ReadInt32(BaseAddress + 0x248);
            set => Memory.WriteInt32(BaseAddress + 0x248, (int)value);
        }
        public MoveState MoveState
        {
            get => (MoveState)Memory.ReadInt32(BaseAddress + 0x24C);
            set => Memory.WriteInt32(BaseAddress + 0x24C, (int)value);
        }
        public MoveState StoredMoveState
        {
            get => (MoveState)Memory.ReadInt32(BaseAddress + 0x250);
            set => Memory.WriteInt32(BaseAddress + 0x250, (int)value);
        }
        public MoveState PreviousMoveState
        {
            get => (MoveState)Memory.ReadInt32(BaseAddress + 0x254);
            set => Memory.WriteInt32(BaseAddress + 0x254, (int)value);
        }
        public WaiteState WaitState
        {
            get => (WaiteState)Memory.ReadInt32(BaseAddress + 0x258);
            set => Memory.WriteInt32(BaseAddress + 0x258, (int)value);
        }
        public int WaitTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x25C);
            set => Memory.WriteInt32(BaseAddress + 0x25C, value);
        }
        // type: int[8] name: pPathNodesStates offset: 0x260 size: 0x20
        // type: int[8] name: pPathNodesStates offset: 0x260 size: 0x20
        public short PathNodes
        {
            get => Memory.ReadInt16(BaseAddress + 0x280);
            set => Memory.WriteInt16(BaseAddress + 0x280, value);
        }
        public short CurrentPathNodeID
        {
            get => Memory.ReadInt16(BaseAddress + 0x282);
            set => Memory.WriteInt16(BaseAddress + 0x282, value);
        }
        public CEntity PathRelEntity
        {
            get => new CEntity((IntPtr)Memory.ReadInt32(BaseAddress + 0x284));
            set => Memory.WriteInt32(BaseAddress + 0x284, value.BaseAddress);
        }
        public CEntity NextNodeEntity
        {
            get => new CEntity((IntPtr)Memory.ReadInt32(BaseAddress + 0x288));
            set => Memory.WriteInt32(BaseAddress + 0x288, value.BaseAddress);
        }
        public int PathNodeTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x28C);
            set => Memory.WriteInt32(BaseAddress + 0x28C, value);
        }
        // type: CPathNode[8] name: stPathNodeStates offset: 0x290 size: 0xA0
        // type: CPathNode[8] name: stPathNodeStates offset: 0x290 size: 0xA0
        public int pCurNodeState
        {
            get => Memory.ReadInt32(BaseAddress + 0x330);
            set => Memory.WriteInt32(BaseAddress + 0x330, value);
        }
        public byte bytePathState
        {
            get => Memory.ReadByte(BaseAddress + 0x334);
            set => Memory.WriteByte(BaseAddress + 0x334, value);
        }
        // type: byte[3] name: __f0331 offset: 0x335 size: 3
        // type: byte[3] name: __f0331 offset: 0x335 size: 3
        public int pNextPathNode //TODO: Add PathNode support here after added to the SDK
        {
            get => Memory.ReadInt32(BaseAddress + 0x338);
            set => Memory.WriteInt32(BaseAddress + 0x338, value);
        }
        public int pLastPathNode //TODO: Add PathNode support here after added to the SDK
        {
            get => Memory.ReadInt32(BaseAddress + 0x33C);
            set => Memory.WriteInt32(BaseAddress + 0x33C, value);
        }
        public CVector PathNextNodeVector
        {
            get => Memory.ReadVector(BaseAddress + 0x340);
            set => Memory.WriteVector(BaseAddress + 0x340, value);
        }
        public float PathNextNodeDir
        {
            get => Memory.ReadFloat(BaseAddress + 0x34C);
            set => Memory.WriteFloat(BaseAddress + 0x34C, value);
        }
        public int PathNodeType
        {
            get => Memory.ReadInt32(BaseAddress + 0x350);
            set => Memory.WriteInt32(BaseAddress + 0x350, value);
        }
        public float Health
        {
            get => Memory.ReadFloat(BaseAddress + 0x354);
            set => Memory.WriteFloat(BaseAddress + 0x354, value);
        }
        public float Armour
        {
            get => Memory.ReadFloat(BaseAddress + 0x358);
            set => Memory.WriteFloat(BaseAddress + 0x358, value);
        }
        public int ShadowUpdateTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x35C);
            set => Memory.WriteInt32(BaseAddress + 0x35C, value);
        }
        public short wRouteLastPoint
        {
            get => Memory.ReadInt16(BaseAddress + 0x360);
            set => Memory.WriteInt16(BaseAddress + 0x360, value);
        }
        public short wRoutePoints
        {
            get => Memory.ReadInt16(BaseAddress + 0x362);
            set => Memory.WriteInt16(BaseAddress + 0x362, value);
        }
        public short wRoutePos
        {
            get => Memory.ReadInt16(BaseAddress + 0x364);
            set => Memory.WriteInt16(BaseAddress + 0x364, value);
        }
        public short wRouteType
        {
            get => Memory.ReadInt16(BaseAddress + 0x366);
            set => Memory.WriteInt16(BaseAddress + 0x366, value);
        }
        public short wRouteCurDir
        {
            get => Memory.ReadInt16(BaseAddress + 0x368);
            set => Memory.WriteInt16(BaseAddress + 0x368, value);
        }
        // type: byte[2] name: __f0366 offset: 0x36A size: 2
        // type: byte[2] name: __f0366 offset: 0x36A size: 2
        public int fMovedX
        {
            get => Memory.ReadInt32(BaseAddress + 0x36C);
            set => Memory.WriteInt32(BaseAddress + 0x36C, value);
        }
        public int fMovedY
        {
            get => Memory.ReadInt32(BaseAddress + 0x370);
            set => Memory.WriteInt32(BaseAddress + 0x370, value);
        }
        public float fRotationCur
        {
            get => Memory.ReadFloat(BaseAddress + 0x374);
            set => Memory.WriteFloat(BaseAddress + 0x374, value);
        }
        public float fRotationDest
        {
            get => Memory.ReadFloat(BaseAddress + 0x378);
            set => Memory.WriteFloat(BaseAddress + 0x378, value);
        }
        public int fHeadingRate
        {
            get => Memory.ReadInt32(BaseAddress + 0x37C);
            set => Memory.WriteInt32(BaseAddress + 0x37C, value);
        }
        public short wEnterType
        {
            get => Memory.ReadInt16(BaseAddress + 0x380);
            set => Memory.WriteInt16(BaseAddress + 0x380, value);
        }
        public short wWalkAroundType
        {
            get => Memory.ReadInt16(BaseAddress + 0x382);
            set => Memory.WriteInt16(BaseAddress + 0x382, value);
        }
        public int pCurPhysSurface
        {
            get => Memory.ReadInt32(BaseAddress + 0x384);
            set => Memory.WriteInt32(BaseAddress + 0x384, value);
        }
        public CVector vecOffsetFromPhysSurface
        {
            get => Memory.ReadVector(BaseAddress + 0x388);
            set => Memory.WriteVector(BaseAddress + 0x388, value);
        }
        public int pCurSurface
        {
            get => Memory.ReadInt32(BaseAddress + 0x394);
            set => Memory.WriteInt32(BaseAddress + 0x394, value);
        }
        public CVector vecSeekVehicle
        {
            get => Memory.ReadVector(BaseAddress + 0x398);
            set => Memory.WriteVector(BaseAddress + 0x398, value);
        }
        public int pSeekTarget
        {
            get => Memory.ReadInt32(BaseAddress + 0x3A4);
            set => Memory.WriteInt32(BaseAddress + 0x3A4, value);
        }
        // type: CVehicle * name: pVehicle offset: 0x3A8 size: 4
        // type: CVehicle * name: pVehicle offset: 0x3A8 size: 4
        public byte byteIsInVehicle
        {
            get => Memory.ReadByte(BaseAddress + 0x3AC);
            set => Memory.WriteByte(BaseAddress + 0x3AC, value);
        }
        // type: byte[3] name: __f03A9 offset: 0x3AD size: 3
        // type: byte[3] name: __f03A9 offset: 0x3AD size: 3
        public int fSeatPrecisionX
        {
            get => Memory.ReadInt32(BaseAddress + 0x3B0);
            set => Memory.WriteInt32(BaseAddress + 0x3B0, value);
        }
        public int fSeatPrecisionY
        {
            get => Memory.ReadInt32(BaseAddress + 0x3B4);
            set => Memory.WriteInt32(BaseAddress + 0x3B4, value);
        }
        public int pFromVehicle
        {
            get => Memory.ReadInt32(BaseAddress + 0x3B8);
            set => Memory.WriteInt32(BaseAddress + 0x3B8, value);
        }
        public int pSeat
        {
            get => Memory.ReadInt32(BaseAddress + 0x3BC);
            set => Memory.WriteInt32(BaseAddress + 0x3BC, value);
        }
        public int SeatType
        {
            get => Memory.ReadInt32(BaseAddress + 0x3C0);
            set => Memory.WriteInt32(BaseAddress + 0x3C0, value);
        }
        public byte byteHasPhone
        {
            get => Memory.ReadByte(BaseAddress + 0x3C4);
            set => Memory.WriteByte(BaseAddress + 0x3C4, value);
        }
        public byte __f03C1
        {
            get => Memory.ReadByte(BaseAddress + 0x3C5);
            set => Memory.WriteByte(BaseAddress + 0x3C5, value);
        }
        public short wPhoneId
        {
            get => Memory.ReadInt16(BaseAddress + 0x3C6);
            set => Memory.WriteInt16(BaseAddress + 0x3C6, value);
        }
        public int LookingForPhone
        {
            get => Memory.ReadInt32(BaseAddress + 0x3C8);
            set => Memory.WriteInt32(BaseAddress + 0x3C8, value);
        }
        public int PhoneTalkTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x3CC);
            set => Memory.WriteInt32(BaseAddress + 0x3CC, value);
        }
        public int pLastAccident
        {
            get => Memory.ReadInt32(BaseAddress + 0x3D0);
            set => Memory.WriteInt32(BaseAddress + 0x3D0, value);
        }
        public int PedType
        {
            get => Memory.ReadInt32(BaseAddress + 0x3D4);
            set => Memory.WriteInt32(BaseAddress + 0x3D4, value);
        }
        public int pPedStats
        {
            get => Memory.ReadInt32(BaseAddress + 0x3D8);
            set => Memory.WriteInt32(BaseAddress + 0x3D8, value);
        }
        public int fFleeFromPosX
        {
            get => Memory.ReadInt32(BaseAddress + 0x3DC);
            set => Memory.WriteInt32(BaseAddress + 0x3DC, value);
        }
        public int fFleeFromPosY
        {
            get => Memory.ReadInt32(BaseAddress + 0x3E0);
            set => Memory.WriteInt32(BaseAddress + 0x3E0, value);
        }
        public int pFleeFrom
        {
            get => Memory.ReadInt32(BaseAddress + 0x3E4);
            set => Memory.WriteInt32(BaseAddress + 0x3E4, value);
        }
        public int FleeTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x3E8);
            set => Memory.WriteInt32(BaseAddress + 0x3E8, value);
        }
        public int pThreatEx
        {
            get => Memory.ReadInt32(BaseAddress + 0x3EC);
            set => Memory.WriteInt32(BaseAddress + 0x3EC, value);
        }
        public int pLastThreatAt
        {
            get => Memory.ReadInt32(BaseAddress + 0x3F0);
            set => Memory.WriteInt32(BaseAddress + 0x3F0, value);
        }
        public int LastThreatTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x3F4);
            set => Memory.WriteInt32(BaseAddress + 0x3F4, value);
        }
        public int pVehicleColliding
        {
            get => Memory.ReadInt32(BaseAddress + 0x3F8);
            set => Memory.WriteInt32(BaseAddress + 0x3F8, value);
        }
        public byte byteStateUnused
        {
            get => Memory.ReadByte(BaseAddress + 0x3FC);
            set => Memory.WriteByte(BaseAddress + 0x3FC, value);
        }
        // type: byte[3] name: __f03F9 offset: 0x3FD size: 3
        // type: byte[3] name: __f03F9 offset: 0x3FD size: 3
        public int TimerUnused
        {
            get => Memory.ReadInt32(BaseAddress + 0x400);
            set => Memory.WriteInt32(BaseAddress + 0x400, value);
        }
        public int pTargetUnused
        {
            get => Memory.ReadInt32(BaseAddress + 0x404);
            set => Memory.WriteInt32(BaseAddress + 0x404, value);
        }
        // type: CWeapon[10] name: stWeps offset: 0x408 size: 0xF0
        // type: CWeapon[10] name: stWeps offset: 0x408 size: 0xF0
        public int AtchStoredWep
        {
            get => Memory.ReadInt32(BaseAddress + 0x4F8);
            set => Memory.WriteInt32(BaseAddress + 0x4F8, value);
        }
        public int StoredGiveWep
        {
            get => Memory.ReadInt32(BaseAddress + 0x4FC);
            set => Memory.WriteInt32(BaseAddress + 0x4FC, value);
        }
        public int StoredGiveAmmo
        {
            get => Memory.ReadInt32(BaseAddress + 0x500);
            set => Memory.WriteInt32(BaseAddress + 0x500, value);
        }
        public byte byteWepSlot
        {
            get => Memory.ReadByte(BaseAddress + 0x504);
            set => Memory.WriteByte(BaseAddress + 0x504, value);
        }
        // type: unsigned __int8 name: byteWepSkills offset: 0x505 size: 1
        public byte byteWepAccuracy
        {
            get => Memory.ReadByte(BaseAddress + 0x506);
            set => Memory.WriteByte(BaseAddress + 0x506, value);
        }
        public byte byteBodyPart
        {
            get => Memory.ReadByte(BaseAddress + 0x507);
            set => Memory.WriteByte(BaseAddress + 0x507, value);
        }
        public int pPointGunAt
        {
            get => Memory.ReadInt32(BaseAddress + 0x508);
            set => Memory.WriteInt32(BaseAddress + 0x508, value);
        }
        public CVector vecHitLastPos
        {
            get => Memory.ReadVector(BaseAddress + 0x50C);
            set => Memory.WriteVector(BaseAddress + 0x50C, value);
        }
        public int HitCounter
        {
            get => Memory.ReadInt32(BaseAddress + 0x518);
            set => Memory.WriteInt32(BaseAddress + 0x518, value);
        }
        public int LastHitState
        {
            get => Memory.ReadInt32(BaseAddress + 0x51C);
            set => Memory.WriteInt32(BaseAddress + 0x51C, value);
        }
        public byte byteFightFlags1
        {
            get => Memory.ReadByte(BaseAddress + 0x520);
            set => Memory.WriteByte(BaseAddress + 0x520, value);
        }
        public byte byteFightFlags2
        {
            get => Memory.ReadByte(BaseAddress + 0x521);
            set => Memory.WriteByte(BaseAddress + 0x521, value);
        }
        public byte byteFightFlags3
        {
            get => Memory.ReadByte(BaseAddress + 0x522);
            set => Memory.WriteByte(BaseAddress + 0x522, value);
        }
        public byte byteBleedCounter
        {
            get => Memory.ReadByte(BaseAddress + 0x523);
            set => Memory.WriteByte(BaseAddress + 0x523, value);
        }
        public int pPedFire
        {
            get => Memory.ReadInt32(BaseAddress + 0x524);
            set => Memory.WriteInt32(BaseAddress + 0x524, value);
        }
        public int pPedFight
        {
            get => Memory.ReadInt32(BaseAddress + 0x528);
            set => Memory.WriteInt32(BaseAddress + 0x528, value);
        }
        public int fLookDirection
        {
            get => Memory.ReadInt32(BaseAddress + 0x52C);
            set => Memory.WriteInt32(BaseAddress + 0x52C, value);
        }
        public int WepModelID
        {
            get => Memory.ReadInt32(BaseAddress + 0x530);
            set => Memory.WriteInt32(BaseAddress + 0x530, value);
        }
        public int LeaveCarTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x534);
            set => Memory.WriteInt32(BaseAddress + 0x534, value);
        }
        public int GetUpTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x538);
            set => Memory.WriteInt32(BaseAddress + 0x538, value);
        }
        public int LookTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x53C);
            set => Memory.WriteInt32(BaseAddress + 0x53C, value);
        }
        public int StandardTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x540);
            set => Memory.WriteInt32(BaseAddress + 0x540, value);
        }
        public int AttackTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x544);
            set => Memory.WriteInt32(BaseAddress + 0x544, value);
        }
        public int LastHitTime
        {
            get => Memory.ReadInt32(BaseAddress + 0x548);
            set => Memory.WriteInt32(BaseAddress + 0x548, value);
        }
        public int HitRecoverTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x54C);
            set => Memory.WriteInt32(BaseAddress + 0x54C, value);
        }
        public int ObjectiveTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x550);
            set => Memory.WriteInt32(BaseAddress + 0x550, value);
        }
        public int DuckTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x554);
            set => Memory.WriteInt32(BaseAddress + 0x554, value);
        }
        public int DuckAndCoverTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x558);
            set => Memory.WriteInt32(BaseAddress + 0x558, value);
        }
        public int BloodyTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x55C);
            set => Memory.WriteInt32(BaseAddress + 0x55C, value);
        }
        public int ShotTime
        {
            get => Memory.ReadInt32(BaseAddress + 0x560);
            set => Memory.WriteInt32(BaseAddress + 0x560, value);
        }
        public int ShotTimeAdd
        {
            get => Memory.ReadInt32(BaseAddress + 0x564);
            set => Memory.WriteInt32(BaseAddress + 0x564, value);
        }
        public byte bytePanicCounter
        {
            get => Memory.ReadByte(BaseAddress + 0x568);
            set => Memory.WriteByte(BaseAddress + 0x568, value);
        }
        public byte byteDeadBleeding
        {
            get => Memory.ReadByte(BaseAddress + 0x569);
            set => Memory.WriteByte(BaseAddress + 0x569, value);
        }
        public byte byteBodyPartBleeding
        {
            get => Memory.ReadByte(BaseAddress + 0x56A);
            set => Memory.WriteByte(BaseAddress + 0x56A, value);
        }
        public byte __f0567
        {
            get => Memory.ReadByte(BaseAddress + 0x56B);
            set => Memory.WriteByte(BaseAddress + 0x56B, value);
        }
        // type: int[10] name: pNearPeds offset: 0x56C size: 0x28
        // type: int[10] name: pNearPeds offset: 0x56C size: 0x28
        public short nNearPeds
        {
            get => Memory.ReadInt16(BaseAddress + 0x594);
            set => Memory.WriteInt16(BaseAddress + 0x594, value);
        }
        public short wPedMoney
        {
            get => Memory.ReadInt16(BaseAddress + 0x596);
            set => Memory.WriteInt16(BaseAddress + 0x596, value);
        }
        public byte byteLastDamWep
        {
            get => Memory.ReadByte(BaseAddress + 0x598);
            set => Memory.WriteByte(BaseAddress + 0x598, value);
        }
        // type: byte[3] name: __f0595 offset: 0x599 size: 3
        // type: byte[3] name: __f0595 offset: 0x599 size: 3
        public int pLastDamEntity
        {
            get => Memory.ReadInt32(BaseAddress + 0x59C);
            set => Memory.WriteInt32(BaseAddress + 0x59C, value);
        }
        public int pAttachedTo
        {
            get => Memory.ReadInt32(BaseAddress + 0x5A0);
            set => Memory.WriteInt32(BaseAddress + 0x5A0, value);
        }
        public CVector vAtchOff
        {
            get => Memory.ReadVector(BaseAddress + 0x5A4);
            set => Memory.WriteVector(BaseAddress + 0x5A4, value);
        }
        public short wAtchType
        {
            get => Memory.ReadInt16(BaseAddress + 0x5B0);
            set => Memory.WriteInt16(BaseAddress + 0x5B0, value);
        }
        // type: byte[2] name: _f05AE offset: 0x5B2 size: 2
        // type: byte[2] name: _f05AE offset: 0x5B2 size: 2
        public int fAtchRot
        {
            get => Memory.ReadInt32(BaseAddress + 0x5B4);
            set => Memory.WriteInt32(BaseAddress + 0x5B4, value);
        }
        public int AtchWepAmmo
        {
            get => Memory.ReadInt32(BaseAddress + 0x5B8);
            set => Memory.WriteInt32(BaseAddress + 0x5B8, value);
        }
        public int ThreatFlags
        {
            get => Memory.ReadInt32(BaseAddress + 0x5BC);
            set => Memory.WriteInt32(BaseAddress + 0x5BC, value);
        }
        public int ThreatCheck
        {
            get => Memory.ReadInt32(BaseAddress + 0x5C0);
            set => Memory.WriteInt32(BaseAddress + 0x5C0, value);
        }
        public int LastThreatCheck
        {
            get => Memory.ReadInt32(BaseAddress + 0x5C4);
            set => Memory.WriteInt32(BaseAddress + 0x5C4, value);
        }
        public int SayType
        {
            get => Memory.ReadInt32(BaseAddress + 0x5C8);
            set => Memory.WriteInt32(BaseAddress + 0x5C8, value);
        }
        public int SayTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x5CC);
            set => Memory.WriteInt32(BaseAddress + 0x5CC, value);
        }
        public int TalkTimerLast
        {
            get => Memory.ReadInt32(BaseAddress + 0x5D0);
            set => Memory.WriteInt32(BaseAddress + 0x5D0, value);
        }
        public int TalkTimer
        {
            get => Memory.ReadInt32(BaseAddress + 0x5D4);
            set => Memory.WriteInt32(BaseAddress + 0x5D4, value);
        }
        public short wTalkTypeLast
        {
            get => Memory.ReadInt16(BaseAddress + 0x5D8);
            set => Memory.WriteInt16(BaseAddress + 0x5D8, value);
        }
        public short wTalkType
        {
            get => Memory.ReadInt16(BaseAddress + 0x5DA);
            set => Memory.WriteInt16(BaseAddress + 0x5DA, value);
        }
        public byte byteCanPedTalk
        {
            get => Memory.ReadByte(BaseAddress + 0x5DC);
            set => Memory.WriteByte(BaseAddress + 0x5DC, value);
        }
        // type: byte[3] name: __f05D9 offset: 0x5DD size: 3
        // type: byte[3] name: __f05D9 offset: 0x5DD size: 3
        public int PedLastComment
        {
            get => Memory.ReadInt32(BaseAddress + 0x5E0);
            set => Memory.WriteInt32(BaseAddress + 0x5E0, value);
        }
        public CVector vecSeekPosEx
        {
            get => Memory.ReadVector(BaseAddress + 0x5E4);
            set => Memory.WriteVector(BaseAddress + 0x5E4, value);
        }
        public int fSeekExAngle
        {
            get => Memory.ReadInt32(BaseAddress + 0x5F0);
            set => Memory.WriteInt32(BaseAddress + 0x5F0, value);
        }


    }
}
