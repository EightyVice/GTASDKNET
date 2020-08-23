using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTASDK.III
{
    public class IIIPlugin
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
            InstallHooks();
        }

        private static void InstallHooks()
        {
            // CutSceneMgr::Update Hook to work as GameTickingEvent
            Memory.Hook((IntPtr)0x404EE0, new Memory.VoidDelegate(GameTickHook));

        }
        private static void GameTickHook()
        {
            // Checks if game is paused
            if (Memory.Read1bBool(0x8F5B9D) == false) GameTicking?.Invoke();
        }

        public Scripting Command = new Scripting();

        // Events
        public delegate void GameTickingHanlder();
        public static event GameTickingHanlder GameTicking;

    }
}
