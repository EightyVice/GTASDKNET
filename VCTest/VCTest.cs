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
        public VCTest(string[] cmdLine)
        {
            AllocConsole();
            GameTicking += GameTick;

            #region code
            //Memory.Hook((IntPtr)0x55BFC0, new CHud__SetHelpMessage(HelpMessageHook));

            //while (true)
            //{
            //    if (IsKeyPressed(Keys.F5))
            //    {
            //        CStreaming.RequestModel(7, StreamingFlags.PRIORITY_REQUEST);
            //        CStreaming.LoadAllRequestedModels(false);

            //        CCivilianPed p = new CCivilianPed(PedType.CIVFEMALE, 7);
            //        CVector playerpos = CPed.FindPlayerPed().Placement.pos;
            //        p.Placement.pos = playerpos;
            //        CWorld.Add(p);
            //        Console.WriteLine($"Spawned with address 0x{p.BaseAddress:X} model id {p.ModelIndex} at {p.Placement.pos.X} {p.Placement.pos.Y} {p.Placement.pos.Z}");
            //        Thread.Sleep(500);
            //    }
            //}

            //Events.GameTicking += GameTick;

            // Install hook
            //Memory.Hook((IntPtr)0x405FA0, new CGame._Process(GameProcessHook));
            #endregion
        }

        static int counter = 0;
        void GameTick()
        {
            ++counter;
            Console.WriteLine($"Ticked {counter} Times");

        }
    }

}
