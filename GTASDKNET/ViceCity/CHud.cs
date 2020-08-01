using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GTASDK;

namespace GTASDK.ViceCity
{
    /// <summary>
    /// Provides static functions and members that alter Hud
    /// </summary>
    public static class CHud
    {
        //------------ Static Members ------------


        //------------ Functions ------------

        //void __cdecl CHud::SetHelpMessage(ushort *,bool,bool) 0055BFC0 0055BFE0 0055BEB0
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void CHud__SetHelpMessage([MarshalAs(UnmanagedType.LPWStr)] string message, bool quickmessage, bool permenant);
        /// <summary>
        /// Shows a help message like "Cheat Activated" one.
        /// </summary>
        /// <param name="Message">Message to be shown</param>
        /// <param name="quickMessage">Show it quickly then dismiss</param>
        /// <param name="permenantMessage">Show it permenantly</param>
        public static void SetHelpMessage(string Message, bool quickMessage = false, bool permenantMessage = false)
        {
            Memory.CallFunction<CHud__SetHelpMessage>(0x55BFC0)(Message, quickMessage, permenantMessage);
            
        }
        

    }
}
