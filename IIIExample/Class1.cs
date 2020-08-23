using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTASDK;
using GTASDK.III;

namespace IIIExample
{
    public class IIIExample : IIIPlugin
    {
        public IIIExample(string[] mainArgs)
        {
            //MessageBox.Show("wait");
            GameTicking += GameTick;
        }

        void GameTick()
        {
            if (IsKeyPressed(Keys.F6))
            {
                CHud.SetHelpMessage("Hello from C#");
            }
        }
    }
}
