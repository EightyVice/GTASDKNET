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
                case 0x53:
                    return GTAVersion.ViceCity10en;                    
                case 0x88:
                    return GTAVersion.ViceCity11en;
                default:
                    return GTAVersion.UNKNOWN;       
                // ... todo: more validating
            }
        }

        public static IntPtr VCReturnAddressByGameVersion(int VC10enAddress, int VC11enAddress, int VCSteamAddress)
        {
            switch (GetGameVersion())
            {
                case GTAVersion.ViceCity10en:
                    return (IntPtr)VC10enAddress;                   
                case GTAVersion.ViceCity11en:
                    return (IntPtr)VC11enAddress;
                case GTAVersion.ViceCitySteam:
                    return (IntPtr)VCSteamAddress;
                default:
                    return (IntPtr)0x00000000;
            }
        }
    }
}
