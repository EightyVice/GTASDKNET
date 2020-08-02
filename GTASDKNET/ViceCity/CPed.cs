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
    public class CPed : CPhysical
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




        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr _FindPlayerPed();
        public static CPed FindPlayerPed()
        {
            IntPtr ptr = Memory.CallFunction<_FindPlayerPed>(0x4BC120)();
            return new CPed(ptr);
        }
        
    }
}
