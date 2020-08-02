using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace GTASDK.ViceCity
{
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

    enum PedAction
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


    public partial class CPed : CPhysical
    {
        public CPed(IntPtr address): base(address){

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





        
    }
}
