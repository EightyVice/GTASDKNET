using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK.ViceCity
{
    public class CGame
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void _Process();
        public static void Process()
        {
            Memory.CallFunction<_Process>(0x4A4410);
        }
    }
}
