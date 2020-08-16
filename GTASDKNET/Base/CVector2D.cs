using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GTASDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CVector2D
    {
        public float X;
        public float Y;

        public CVector2D(CVector2D src)
        {
            X = src.X;
            Y = src.Y;
        }

        public CVector2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Magnitude()
        {
            return (float)Math.Sqrt((double)X * (double)X + (double)Y * (double)Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Magnitude2D()
        {
            return (float)Math.Sqrt((double)X * (double)X + (double)Y * (double)Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float MagnitudeSqr()
        {
            return (float)((double)X * (double)X + (double)Y * (double)Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Normalize()
        {
            var length = (float)Math.Sqrt((double)X * (double)X + (double)Y * (double)Y);
            X /= length;
            Y /= length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float NormalizeAndMag()
        {
            var length = (float)Math.Sqrt((double)X * (double)X + (double)Y * (double)Y);
            X /= length;
            Y /= length;
            return length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Sum(CVector2D left, CVector2D right)
        {
            this = left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Difference(CVector2D left, CVector2D right)
        {
            this = left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Set(float x, float y, float z)
        {
            X = x;
            Y = y;
        }

        // Casts to double to prevent loss of accuracy on squaring
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Dot(CVector2D a, CVector2D b)
        {
            return (float)((double)a.X * (double)b.X + (double)a.Y * (double)b.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DistanceBetweenPoints(CVector2D a, CVector2D b)
        {
            var xDiff = a.X - b.X;
            var yDiff = a.Y - b.Y;
            return (float)Math.Sqrt((double)xDiff * (double)xDiff + (double)yDiff * (double)yDiff);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DistanceBetweenPointsSqr(CVector2D a, CVector2D b)
        {
            var xDiff = a.X - b.X;
            var yDiff = a.Y - b.Y;
            return (float)((double)xDiff * (double)xDiff + (double)yDiff * (double)yDiff);
        }

        public override bool Equals(object other)
        {
            if (!(other is CVector2D vector)) return false;
            return this == vector;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                return hashCode;
            }
        }

        // TODO this will only compare vectors exactly identical in memory, should it use an epsilon?
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(CVector2D l, CVector2D r)
            => l.X == r.X && l.Y == r.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(CVector2D l, CVector2D r)
            => l.X != r.X && l.Y != r.Y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector2D operator +(CVector2D l, CVector2D r)
            => new CVector2D(l.X + r.X, l.X + r.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector2D operator -(CVector2D l, CVector2D r)
            => new CVector2D(l.X - r.X, l.X - r.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector2D operator *(CVector2D l, CVector2D r)
            => new CVector2D(l.X * r.X, l.X * r.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector2D operator *(CVector2D l, float multiplier)
            => new CVector2D(l.X * multiplier, l.X * multiplier);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector2D operator *(float multiplier, CVector2D l)
            => new CVector2D(l.X * multiplier, l.X * multiplier);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector2D operator /(CVector2D l, CVector2D r)
            => new CVector2D(l.X / r.X, l.X / r.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector2D operator /(CVector2D l, float divisor)
            => new CVector2D(l.X / divisor, l.X / divisor);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CVector2D operator /(float divisor, CVector2D l)
            => new CVector2D(divisor / l.X, divisor / l.X);
    }
}
