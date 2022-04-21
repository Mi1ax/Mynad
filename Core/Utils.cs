using System.Numerics;
using System.Text.RegularExpressions;
using Raylib_CsLo;
using ColorRAY = Raylib_CsLo.Color;
using ColorSYS = System.Drawing.Color;
using Rectangle = Core.Drawing.Shapes.Rectangle;

namespace Core
{
    public static class Utils
    {
        public static ColorRAY GetColorRayFromSys(ColorSYS sysColor) =>
            new (sysColor.R, sysColor.G, sysColor.B, sysColor.A);

        public static ColorSYS GetColorSysFromRay(ColorRAY rayColor) =>
            ColorSYS.FromArgb(rayColor.a, rayColor.r, rayColor.g, rayColor.b);

        public static bool IsInRect(Rectangle rectangle, Vector2 position) =>
            position.X > rectangle.Position.X && position.X < rectangle.Position.X + rectangle.Size.Width &&
            position.Y > rectangle.Position.Y && position.Y < rectangle.Position.Y + rectangle.Size.Height;
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