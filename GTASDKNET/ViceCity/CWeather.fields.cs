using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK.ViceCity
{
    public enum Weather : short
    {
        Sunny = 0,
        Cloudy = 1,
        Rainy = 2,
        Foggy = 3,
        Sunnier = 4,
        Hurricane = 5
    }


    public partial class CWeather
    {
        public static Weather OldWeather
        {
            get => (Weather)Memory.ReadInt16(0xA10AAA);
            set => Memory.WriteInt16(0xA10AAA, (short)value);
        }
        public static Weather NewWeather
        {
            get => (Weather)Memory.ReadInt16(0xA10A2E);
            set => Memory.WriteInt16(0xA10A2E, (short)value);
        }
        public static Weather ForcedWeather
        {
            get => (Weather)Memory.ReadInt16(0xA10A42);
            set => Memory.WriteInt16(0xA10A42, (short)value);
        }
        public static bool LightningFlash
        {
            get => Memory.Read4bBool(0xA10B67);
            set => Memory.Write4bBool(0xA10B67, value);
        }
        public static bool LightningBurst
        {
            get => Memory.Read4bBool(0xA10B72);
            set => Memory.Write4bBool(0xA10B72, value);
        }

        /* To be done:
            int &CWeather::LightningStart = *(int*)0x9B5F84;
            int &CWeather::SoundHandle = *(int*)0x699EDC;
            int &CWeather::StreamAfterRainTimer = *(int*)0x699EE0; 
        */
    }
}
