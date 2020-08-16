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

    [PluginInfo(Author = "EightyVice", Version = "1.0")]
    public class VCTest : VCPlugin
    {
        public VCTest(string[] cmdLine)
        {
            AllocConsole();
            GameTicking += GameTick;
        }

        void GameTick()
        {
            if (IsKeyPressed(Keys.F5)) // Spawn Ped
            {
                CStreaming.RequestModel(7, StreamingFlags.PriorityRequest);
                CStreaming.LoadAllRequestedModels(false);
                if (CStreaming.GetInfoForModel(7).LoadState == StreamingLoadState.Loaded)
                {
                    CCivilianPed p = new CCivilianPed(PedType.CIVFEMALE, 7);
                    CVector playerpos = CPed.FindPlayerPed().Placement.pos;
                    p.Placement.pos = playerpos;
                    CWorld.Add(p);
                    Console.WriteLine($"Spawned with address 0x{p.BaseAddress:X} model id {p.ModelIndex} at {p.Placement.pos.X} {p.Placement.pos.Y} {p.Placement.pos.Z}");
                    
                }
            }

            if (IsKeyPressed(Keys.F6)) // Spawn Vehicle
            {
                CStreaming.RequestModel(232, StreamingFlags.PriorityRequest);
                CStreaming.LoadAllRequestedModels(false);
                CAutomobile car = new CAutomobile(232, 1);
                car.State = 4;
                var pos = CPed.FindPlayerPed().Placement.pos;
                car.Placement.pos = pos;
                Console.WriteLine($"232 is loaded at address {car.BaseAddress:X}");
                CWorld.Add(car);
            }

            if (IsKeyPressed(Keys.F7))
            {
                Memory.WriteString(0x68F714, "DEAD\0\0");
                Console.WriteLine(Memory.ReadString(0x68F714, 8));
            }
        }
    }

}
