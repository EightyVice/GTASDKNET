using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

using System.Windows.Forms;
using GTASDK.ViceCity;

namespace GTASDK
{
    public class Plugin
    {
        [DllImport("USER32.dll")]
        static extern short GetKeyState(int nVirtKey);

        [DllImport("kernel32")]
        public static extern bool AllocConsole();

        public bool IsKeyPressed(Keys key)
        {
            return (GetKeyState((int)key) & 0x8000) != 0;
        }

        public static void PluginInit()
        {
            // Hook Events
            Memory.Hook((IntPtr)0x4A4410, new CGame._Process(Events._GameProcessHook));

        }


        public static class Events
        {
            public delegate void GameTickingHanlder();
            public static event GameTickingHanlder GameTicking;

            public static void _GameProcessHook()
            {
                GameTicking();      // Raise the event
                CGame.Process();    // Call original function
            }
        }
    }
}
