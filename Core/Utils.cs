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
}