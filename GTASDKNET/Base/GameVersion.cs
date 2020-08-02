using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK
{
    public enum GTAVersion
    {
        UNKNOWN = 0,
        III10en,
        III11en,
        IIISteam,
        ViceCity10en,
        ViceCity11en,
        ViceCitySteam,
    }
    public enum GTAGame
    {
        III,
        ViceCity,
        SanAndreas
    }
    class GameVersion
    {
        public static GTAVersion GetGameVersion()
        {
            byte ValidByte = (byte)Memory.ReadByte(0x667BED);
            switch (ValidByte)
            {
                case 0x90:
                    return GTAVersion.ViceCity10en;                    
                case 0x88:
                    return GTAVersion.ViceCity11en;
                case 0x34:
                    return GTAVersion.ViceCitySteam;
                default:
                    return GTAVersion.UNKNOWN;       
                // ... todo: more validating
            }
        }

        /// <summary>
        /// Returns address by vice city version
        /// </summary>
        /// <param name="VC10enAddress">Vice City 10 EN Address</param>
        /// <param name="VC11enAddress">Vice City </param>
        /// <param name="VCSteamAddress"></param>
        /// <returns></returns>
        public static int VCRABV(int VC10enAddress, int VC11enAddress, int VCSteamAddress)
        {
            switch (GetGameVersion())
            {
                case GTAVersion.ViceCity10en:
                    return VC10enAddress;                   
                case GTAVersion.ViceCity11en:
                    return VC11enAddress;
                case GTAVersion.ViceCitySteam:
                    return VCSteamAddress;
                default:
                    return 0x00000000;
            }
        }
    }
}
