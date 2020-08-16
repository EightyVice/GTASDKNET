using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK.ViceCity
{
    public partial class CAutomobile
    {
        public CAutomobile(IntPtr Address) : base(Address) { }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate IntPtr _Construtor(IntPtr _t, int m, byte c);
        public CAutomobile(int modelIndex, byte createdBy) : base(IntPtr.Zero)
        {
            // Call CVehicle:: new operator that allocates memory
            IntPtr p = New(0x5DC);
            BaseAddress = Memory.CallFunction<_Construtor>(0x59E620)(p, modelIndex, createdBy).ToInt32();
        }

    }
}
