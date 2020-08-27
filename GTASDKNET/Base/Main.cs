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
        public static void Init()
        {
            // Load plugins
            PluginsLoader loader = new PluginsLoader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Environment.GetCommandLineArgs());
            loader.LoadPluginAssemblies();
            loader.InitAllScripts();
        }
    }
}
