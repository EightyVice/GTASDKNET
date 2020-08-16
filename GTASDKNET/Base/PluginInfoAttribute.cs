using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PluginInfoAttribute : Attribute
    {
        public string Author;
        public string Version;
    }
}
