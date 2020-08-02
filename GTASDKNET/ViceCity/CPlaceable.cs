using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace GTASDK.ViceCity
{

    public class CPlaceable : CMatrix
    {
        public CPlaceable(int address)
        {
            BaseAddress = address;
        }
    }
}
