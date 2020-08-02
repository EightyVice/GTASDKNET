using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PluginOptionsAttribute : Attribute
    {
        public bool OwnThread;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="OwnThread">Indicates whether the plugin is loaded on its own thread or game's thread.</param>
        public PluginOptionsAttribute()
        {

        }
    }
}
