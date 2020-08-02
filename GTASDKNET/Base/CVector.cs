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
        public float X, Y, Z;

        public CVector(float x, float y, float z) { X = x; Y = y; Z = z; }
        public static CVector operator +(CVector l, CVector r)
        {
            return new CVector(l.X + r.X, l.X + r.Y, l.Z + l.Y);
        }
       
        // todo Add operators
    }
}
