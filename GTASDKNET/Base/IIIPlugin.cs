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

    }
}
