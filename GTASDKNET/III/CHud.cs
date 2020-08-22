using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK.III
{
    public class CHud
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void _SetHelpMessage([MarshalAs(UnmanagedType.LPWStr)] string s, bool q);
        public static void SetHelpMessage(string Message, bool Quick = false)
        {
            Memory.CallFunction<_SetHelpMessage>(0x5052C0)(Message, Quick);
        }
    }
}
