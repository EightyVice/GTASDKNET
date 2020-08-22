using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK.ViceCity
{
    public static class CMessages
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void _AddBigMessage([MarshalAs(UnmanagedType.LPWStr)]string s, int t, short st);
        public static void AddBigMessage(string Message, int Time, short Style)
        {
            Memory.CallFunction<_AddBigMessage>(0x584050)(Message, Time, Style);
        }
    }
}
