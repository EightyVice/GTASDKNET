using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTASDK;
using GTASDK.ViceCity;
using EasyHook;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace VCTest
{
    [PluginInfo(Author = "EightyVice", Game = GTAGame.ViceCity, Version = "1.0")]
    public class VCTest : Plugin
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void CHud__SetHelpMessage([MarshalAs(UnmanagedType.LPWStr)] string message, bool quickmessage, bool permenant);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void CStreaming__RequestModel(int id, int f);

        public VCTest(string[] cmdLine)
        {
            AllocConsole();

            Memory.Hook((IntPtr)0x55BFC0, new CHud__SetHelpMessage(HelpMessageHook));

            while (true)
            {
                if (IsKeyPressed(Keys.F5))
                {
                    CStreaming.RequestModel(7, StreamingFlags.PRIORITY_REQUEST);
                    CStreaming.LoadAllRequestedModels(false);

                    CCivilianPed p = new CCivilianPed(PedType.CIVFEMALE, 7);
                    CVector playerpos = CPed.FindPlayerPed().Placement.pos;
                    p.Placement.pos = playerpos;
                    CWorld.Add(p);
                    Console.WriteLine($"Spawned with address 0x{p.BaseAddress:X} model id {p.ModelIndex} at {p.Placement.pos.X} {p.Placement.pos.Y} {p.Placement.pos.Z}");
                    Thread.Sleep(500);
                }
            }
        }

        static void RequestModelHook(int model, int flag)
        {
            Console.WriteLine($"Requested model {model}");
            // Call original
            //CStreaming.RequestModel(model, (StreamingFlags)flag);
        }
        static void HelpMessageHook([MarshalAs(UnmanagedType.LPWStr)] string message, bool quickmessage, bool permenant)
        {
            Console.WriteLine(message);
            // Call original
            CHud.SetHelpMessage(message, quickmessage, permenant);
        }
    }

}
