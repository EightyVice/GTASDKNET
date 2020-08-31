using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK.SanAndreas
{
    public static class CHud
    {
        public static void Draw()
        {
            Memory.CallFunction<Memory.VoidDelegate>(0x58FAE0)();
        }

        public static void DrawAfterFade()
        {
            Memory.CallFunction<Memory.VoidDelegate>(0x58D490)();
        }

        public static void DrawAreaName()
        {
            Memory.CallFunction<Memory.VoidDelegate>(0x58AA50)();
        }

        public static void DrawBustedWastedMessage()
        {
            Memory.CallFunction<Memory.VoidDelegate>(0x58CA50)();
        }

        public static void DrawCrossHairs()
        {
            Memory.CallFunction<Memory.VoidDelegate>(0x58E020)();
        }

        public static void DrawMissionTitle()
        {
            Memory.CallFunction<Memory.VoidDelegate>(0x58D240)();
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void _DrawOddJobMessage(byte p);
        public static void DrawOddJobMessage(byte Priority)
        {
            Memory.CallFunction<_DrawOddJobMessage>(0x58CC80)(Priority);
        }

        public static void DrawRadar()
        {
            Memory.CallFunction<Memory.VoidDelegate>(0x58A330)();
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void _DrawScriptText(byte p);
        public static void DrawScriptText(byte Priority)
        {
            Memory.CallFunction<_DrawScriptText>(0x58C080)(Priority);
        }

        public static void DrawSubtitles()
        {
            Memory.CallFunction<Memory.VoidDelegate>(0x58C250)();
        }

        public static void DrawSuccessFailedMessage()
        {
            Memory.CallFunction<Memory.VoidDelegate>(0x58C6A0)();
        }

        public static void DrawVehicleName()
        {
            Memory.CallFunction<Memory.VoidDelegate>(0x58AEA0)();
        }

        public static void DrawVitalStats()
        {
            Memory.CallFunction<Memory.VoidDelegate>(0x589650)();
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool _HelpMessageDisplayed();
        public static bool HelpMessageDisplayed()
        {
            return Memory.CallFunction<_HelpMessageDisplayed>(0x588B50)();
        }

        public static void Initialise()
        {
            Memory.CallFunction<Memory.VoidDelegate>(0x5BA850)();
        }


        public static void ReInitialise()
        {
            Memory.CallFunction<Memory.VoidDelegate>(0x588880)();
        }

        public static void ResetWastedText()
        {
            Memory.CallFunction<Memory.VoidDelegate>(0x589070)();
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void _SetBigMessage(string t, short s);
        public static void SetBigMessage(string Text, short Style)
        {
            Memory.CallFunction<_SetBigMessage>(0x588BE0)(Text, Style);
        }

    }
}
