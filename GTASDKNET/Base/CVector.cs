using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace GTASDK
{
    //[StructLayout(LayoutKind.Sequential)]
    public struct CVector
    {
        public float X, Y, Z;

        public CVector(float x, float y, float z) { X = x; Y = y; Z = z; }

        // Casts to double to prevent loss of accuracy on squaring
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(Vector3 a, Vector3 b)
        {
            return (float)((double)a.X * (double)b.X + (double)a.Y * (double)b.Y + (double)a.Z * (double)b.Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3(
                (float)((double)a.Y * (double)b.Z - (double)a.Z * (double)b.Y),
                (float)((double)a.Z * (double)b.X - (double)a.X * (double)b.Z),
                (float)((double)a.X * (double)b.Y - (double)a.Y * (double)b.X)
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Distance(Vector3 a, Vector3 b)
        {
            var xDiff = a.X - b.X;
            var yDiff = a.Y - b.Y;
            var zDiff = a.Z - b.Z;
            return (float)Math.Sqrt((double)xDiff * (double)xDiff + (double)yDiff * (double)yDiff + (double)zDiff * (double)zDiff);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DistanceSqr(Vector3 a, Vector3 b)
        {
            var xDiff = a.X - b.X;
            var yDiff = a.Y - b.Y;
            var zDiff = a.Z - b.Z;
            return (float)((double)xDiff * (double)xDiff + (double)yDiff * (double)yDiff + (double)zDiff * (double)zDiff);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Length()
        {
            return (float)Math.Sqrt((double)X * (double)X + (double)Y * (double)Y + (double)Z * (double)Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float LengthSqr()
        {
            return (float)((double)X * (double)X + (double)Y * (double)Y + (double)Z * (double)Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Normalize(Vector3 value)
        {
            var length = (float)Math.Sqrt((double)value.X * (double)value.X + (double)value.Y * (double)value.Y + (double)value.Z * (double)value.Z);
            return new Vector3(value.X / length, value.Y / length, value.Z / length);
        }

        public override bool Equals(object other)
        {
            if (!(other is CVector vector)) return false;
            return this == vector;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        // TODO this will only compare vectors exactly identical in memory, should it use an epsilon?
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(CVector l, CVector r) => l.X == r.X && l.Y == r.Y && l.Z == r.Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(CVector l, CVector r) => l.X != r.X && l.Y != r.Y && l.Z != r.Z;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector operator +(CVector l, CVector r)
        {
            return new CVector(l.X + r.X, l.X + r.Y, l.Z + l.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector operator -(CVector l, CVector r)
        {
            return new CVector(l.X - r.X, l.X - r.Y, l.Z - l.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector operator *(CVector l, CVector r)
        {
            return new CVector(l.X * r.X, l.X * r.Y, l.Z * l.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector operator /(CVector l, CVector r)
        {
            return new CVector(l.X / r.X, l.X / r.Y, l.Z / l.Y);
        }
    }
}
