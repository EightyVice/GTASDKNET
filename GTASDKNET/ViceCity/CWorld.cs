using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK.ViceCity
{
    public class CWorld
    {


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void CWorld__Add(IntPtr ptr);
        public static void Add(CEntity entity)
        {
            Memory.CallFunction<CWorld__Add>(0x4DB3F0)((IntPtr)entity.BaseAddress);
        }
    }
}
