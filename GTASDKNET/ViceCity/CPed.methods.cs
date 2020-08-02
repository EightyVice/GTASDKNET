using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK.ViceCity
{
    public partial class CPed
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr _FindPlayerPed();
        public static CPed FindPlayerPed()
        {
            IntPtr ptr = Memory.CallFunction<_FindPlayerPed>(0x4BC120)();
            return new CPed(ptr);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void CPed__AnswerMobile(IntPtr _this);
        public void AnswerMobile()
        {
            Memory.CallFunction<CPed__AnswerMobile>(0x4F5710)((IntPtr)BaseAddress);
        }
    }
}
