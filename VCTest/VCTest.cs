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
    [PluginInfo(Author = "EightyVice", Game = GTAGame.ViceCity, Version = "1.0")]
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

                    CCivilianPed p = new CCivilianPed(ePedType.PEDTYPE_CIVFEMALE, 7);
                    p.Placement.pos = CPed.FindPlayerPed().Placement.pos;
                    var pos = CPed.FindPlayerPed().Placement.pos;
                    CWorld.Add(p);
                    Console.WriteLine("Spawned with address 0x{0} model id {1} at {2} {3} {4}", p.BaseAddress.ToString("X"), p.ModelIndex, p.Placement.pos.x, p.Placement.pos.y, p.Placement.pos.z);
                    Thread.Sleep(500);
                }
            }
        }
        
    }

}
