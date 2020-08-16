using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK.ViceCity
{
    public partial class CVehicle
    {
        public CVehicle(IntPtr Address) : base(Address) { }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr _New(int s);
        public static IntPtr New(int size)
        {
            return Memory.CallFunction<_New>(0x5BAB20)(size);
        }

    }

}
