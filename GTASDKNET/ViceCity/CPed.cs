using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace GTASDK.ViceCity
{
    public enum ePedType
    {
        PEDTYPE_PLAYER1,
        PEDTYPE_PLAYER2,
        PEDTYPE_PLAYER3,
        PEDTYPE_PLAYER4,
        PEDTYPE_CIVMALE,
        PEDTYPE_CIVFEMALE,
        PEDTYPE_COP,
        PEDTYPE_GANG1,
        PEDTYPE_GANG2,
        PEDTYPE_GANG3,
        PEDTYPE_GANG4,
        PEDTYPE_GANG5,
        PEDTYPE_GANG6,
        PEDTYPE_GANG7,
        PEDTYPE_GANG8,
        PEDTYPE_GANG9,
        PEDTYPE_EMERGENCY,
        PEDTYPE_FIREMAN,
        PEDTYPE_CRIMINAL,
        PEDTYPE_UNUSED1,
        PEDTYPE_PROSTITUTE,
        PEDTYPE_SPECIAL,
        PEDTYPE_UNUSED2,

        NUM_PEDTYPES
    }
    public class CPed : CPhysical
    {
        public CPed(IntPtr Address): base(Address){

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




        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr _FindPlayerPed();
        public static CPed FindPlayerPed()
        {
            IntPtr ptr = Memory.CallFunction<_FindPlayerPed>(0x4BC120)();
            return new CPed(ptr);
        }
        
    }
}
