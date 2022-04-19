using System.Text.RegularExpressions;
using Raylib_CsLo;
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

        public static string GetPath(string relativePath)
        {
            var appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var pattern = @"^(.+\\)(.+exe)$";
            var regex = new Regex(pattern, RegexOptions.None);
            var match = regex.Match(appPath);
            return System.IO.Path.GetFullPath(match.Groups[1].Value + relativePath);
        }
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