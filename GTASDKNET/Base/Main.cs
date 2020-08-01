using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GTASDK.ViceCity;
namespace GTASDK
{
    public class Main
    {
        public static void Init(string cmdLine)
        {
            string[] cmds = cmdLine.Split(' ');
            
            // Load plugins
            PluginsLoader loader = new PluginsLoader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Environment.GetCommandLineArgs());
            loader.InitAllScripts();

            // Setup plugins events
            //PluginEventsManager pem = new PluginEventsManager(loader.Classes);

        }
    }
}
