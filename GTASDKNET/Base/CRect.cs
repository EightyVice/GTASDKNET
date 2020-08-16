using System.Runtime.InteropServices;

namespace GTASDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CRect
    {
        public float Left;
        public float Bottom;
        public float Right;
        public float Top;

        public CRect(float left, float top, float right, float bottom)
        {
            Left = left;
            Bottom = bottom;
            Right = right;
            Top = top;
        }
        
        // Empty struct constructor not allowed!
        public static CRect Default => new CRect(1000000.0f, 1000000.0f, -1000000.0f, -1000000.0f);

        public CRect(CRect src)
        {
            Left = src.Left;
            Bottom = src.Bottom;
            Right = src.Right;
            Top = src.Top;
        }

        public bool IsFlipped()
        {
            return Left > Right || Top > Bottom;
        }

        public void Restrict(ref CRect restriction)
        {
            if (restriction.Left < Left)
                Left = restriction.Left;
            if (restriction.Right > Right)
                Right = restriction.Right;
            if (restriction.Top < Top)
                Top = restriction.Top;
            if (restriction.Bottom > Bottom)
                Bottom = restriction.Bottom;
        }

        public void Resize(float resizeX, float resizeY)
        {
            Left = Left - resizeX;
            Right = resizeX + Right;
            Top = Top - resizeY;
            Bottom = resizeY + Bottom;
        }

        public bool IsPointInside(ref CVector2D point)
        {
            return point.X >= Left
                && point.X <= Right
                && point.Y >= Top
                && point.Y <= Bottom;
        }

        public bool IsCircleInside(ref CVector2D circleCenter, float circleRadius)
        {
            return Left - circleRadius <= circleCenter.X
                && circleRadius + Right >= circleCenter.Y
                && Top - circleRadius <= circleCenter.Y
                && circleRadius + Bottom >= circleCenter.Y;
        }

        public void SetFromCenter(float x, float y, float size)
        {
            Left = x - size;
            Top = y - size;
            Right = x + size;
            Bottom = y + size;
        }

        public void GetCenter(out float x, out float y)
        {
            x = (Right + Left) * 0.5f;
            y = (Top + Bottom) * 0.5f;
        }

        public void StretchToPoint(float x, float y)
        {
            if (x < Left)
                Left = x;
            if (x > Right)
                Right = x;
            if (y < Top)
                Top = y;
            if (y > Bottom)
                Bottom = y;
        }
    }
}
