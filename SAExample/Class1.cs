using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTASDK;
using GTASDK.SanAndreas;

namespace SAExample
{
    public class SAExample : SAPlugin
    {
        public SAExample(string[] cmdLine)
        {
            GameTicking += GameTick;
        }

        private void GameTick()
        {
            //..
        }
    }
}
