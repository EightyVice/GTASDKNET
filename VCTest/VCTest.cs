using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTASDK;
using GTASDK.ViceCity;

namespace VCTest
{
    public class VCTest : Plugin
    {
        public VCTest(string[] cmdLine)
        {
            AllocConsole();
            while (true)
            {
                if (IsKeyPressed(Keys.F5))
                {
                    CStreaming.RequestModel(7, StreamingFlags.PRIORITY_REQUEST);
                    CStreaming.LoadAllRequestedModels(false);

                    var p = new CCivilianPed(ePedType.PEDTYPE_CIVFEMALE, 7);
                    p.Placement.pos = CPed.FindPlayerPed().Placement.pos;
                    var pos = CPed.FindPlayerPed().Placement.pos;
                    CWorld.Add(p);
                    p.Placement.pos = CPed.FindPlayerPed().Placement.pos;
                    Console.WriteLine($"Spawned with address 0x{p.BaseAddress:X} model id {p.ModelIndex} at {p.Placement.pos.X} {p.Placement.pos.Y} {p.Placement.pos.Z}");
                    Thread.Sleep(500);
                }
            }
        }
        
    }

}
