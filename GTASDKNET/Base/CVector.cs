using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GTASDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CVector
    {
        public float X, Y, Z;

        public CVector(float x, float y, float z) { X = x; Y = y; Z = z; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Magnitude()
        {
            return (float)Math.Sqrt((double)X * (double)X + (double)Y * (double)Y + (double)Z * (double)Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Magnitude2D()
        {
            return (float)Math.Sqrt((double)X * (double)X + (double)Y * (double)Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float MagnitudeSqr()
        {
            return (float)((double)X * (double)X + (double)Y * (double)Y + (double)Z * (double)Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Normalize()
        {
            var length = (float)Math.Sqrt((double)X * (double)X + (double)Y * (double)Y + (double)Z * (double)Z);
            X /= length;
            Y /= length;
            Z /= length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float NormalizeAndMag()
        {
            var length = (float)Math.Sqrt((double)X * (double)X + (double)Y * (double)Y + (double)Z * (double)Z);
            X /= length;
            Y /= length;
            Z /= length;
            return length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Cross(CVector a, CVector b)
        {
            X = (float)((double)a.Y * (double)b.Z - (double)a.Z * (double)b.Y);
            Y = (float)((double)a.Z * (double)b.X - (double)a.X * (double)b.Z);
            Z = (float)((double)a.X * (double)b.Y - (double)a.Y * (double)b.X);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Sum(CVector left, CVector right)
        {
            this = left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Difference(CVector left, CVector right)
        {
            this = left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Set(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // Casts to double to prevent loss of accuracy on squaring
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(Vector3 a, Vector3 b)
        {
            return (float)((double)a.X * (double)b.X + (double)a.Y * (double)b.Y + (double)a.Z * (double)b.Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DistanceBetweenPoints(Vector3 a, Vector3 b)
        {
            var xDiff = a.X - b.X;
            var yDiff = a.Y - b.Y;
            var zDiff = a.Z - b.Z;
            return (float)Math.Sqrt((double)xDiff * (double)xDiff + (double)yDiff * (double)yDiff + (double)zDiff * (double)zDiff);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DistanceBetweenPointsSqr(Vector3 a, Vector3 b)
        {
            var xDiff = a.X - b.X;
            var yDiff = a.Y - b.Y;
            var zDiff = a.Z - b.Z;
            return (float)((double)xDiff * (double)xDiff + (double)yDiff * (double)yDiff + (double)zDiff * (double)zDiff);
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
        public static bool operator ==(CVector l, CVector r)
            => l.X == r.X && l.Y == r.Y && l.Z == r.Z;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(CVector l, CVector r)
            => l.X != r.X && l.Y != r.Y && l.Z != r.Z;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector operator +(CVector l, CVector r)
            => new CVector(l.X + r.X, l.X + r.Y, l.Z + r.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector operator -(CVector l, CVector r)
            => new CVector(l.X - r.X, l.X - r.Y, l.Z - r.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector operator *(CVector l, CVector r)
            => new CVector(l.X * r.X, l.X * r.Y, l.Z * r.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector operator *(CVector l, float multiplier)
            => new CVector(l.X * multiplier, l.X * multiplier, l.Z * multiplier);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector operator *(float multiplier, CVector l)
            => new CVector(l.X * multiplier, l.X * multiplier, l.Z * multiplier);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector operator /(CVector l, CVector r)
            => new CVector(l.X / r.X, l.X / r.Y, l.Z / r.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector operator /(CVector l, float divisor)
            => new CVector(l.X / divisor, l.X / divisor, l.Z / divisor);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector operator /(float divisor, CVector l)
            => new CVector(divisor / l.X, divisor / l.X, divisor / l.Z);

    }
}
