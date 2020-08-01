using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK.ViceCity
{
    public class CCivilianPed : CPed
    {
        public CCivilianPed(IntPtr address) : base(address)
        {

        }


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr CPed__new(uint size);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr CCivilianPed_Ctor(IntPtr _this, int pt, int m);
        public CCivilianPed(ePedType pedType, int modelIndex) : base((IntPtr)0x00000)
        {
            IntPtr ptr = Memory.CallFunction<CPed__new>(0x50DA60)(0x648);
            IntPtr baseaddr = Memory.CallFunction<CCivilianPed_Ctor>(0x4EAE00)(ptr, (int)pedType, modelIndex);
            BaseAddress = baseaddr.ToInt32();
        }
    }
}
