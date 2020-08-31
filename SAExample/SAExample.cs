using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTASDK;
using GTASDK.SanAndreas;
using System.Windows.Forms;

namespace SAExample
{
    public class SAExample : SAPlugin
    {
        public SAExample(string[] cmdLine)
        {
            MessageBox.Show("LOADED");
            GameTicking += GameTick;
        }

        private void GameTick()
        {
            if (IsKeyPressed(Keys.F6))
            {
                CHud.SetBigMessage("HELLO", 1);
            }
        }
    }
}
