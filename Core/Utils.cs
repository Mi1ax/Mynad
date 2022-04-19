using ColorRAY = Raylib_CsLo.Color;
using ColorSYS = System.Drawing.Color;

namespace Core
{
    public static class Utils
    {
        public static ColorRAY GetColorRayFromSys(ColorSYS sysColor) =>
            new (sysColor.R, sysColor.G, sysColor.B, sysColor.A);

        public static ColorSYS GetColorSysFromRay(ColorRAY rayColor) =>
            ColorSYS.FromArgb(rayColor.a, rayColor.r, rayColor.g, rayColor.b);
    }
    
    public struct Margin
    {
        public int Left { get; }
        public int Right { get; }
        public int Top { get; }
        public int Bottom { get; }

        public Margin(int left, int right, int top, int bottom)
        {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
        }
    }
}