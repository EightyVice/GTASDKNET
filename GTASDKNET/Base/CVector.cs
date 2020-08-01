using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK
{
    //[StructLayout(LayoutKind.Sequential)]
    public struct CVector
    {
        public float x, y, z;

        public CVector(float X, float Y, float Z) { x = X; y = Y; z = Z; }
        public static CVector operator +(CVector l, CVector r)
        {
            return new CVector(l.x + r.x, l.x + r.y, l.z + l.y);
        }
       
        // todo Add operators
    }
}
