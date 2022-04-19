using Raylib_CsLo;
using static Raylib_CsLo.RayGui;
using static Raylib_CsLo.Raylib;

namespace Core.Drawing.GUI
{
    public struct FontSize
    {
        public static readonly float Default = GuiGetStyle((int)GuiControl.DEFAULT, (int)GuiDefaultProperty.TEXT_SIZE);
        public static readonly float Medium = Default + Multiplier;
        public static readonly float Big = Default + Multiplier * 2;
        public const float Multiplier = 10f;
    }
}