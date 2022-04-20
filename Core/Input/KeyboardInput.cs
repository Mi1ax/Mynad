using Raylib_CsLo;
using R = Raylib_CsLo.Raylib;

namespace Core.Input
{
    public static class KeyboardInput
    {
        public static int GetCharPressed() => R.GetCharPressed();
        public static bool IsKeyPressed(Keys key) => R.IsKeyPressed((int)key);
        public static Keys GetKeyPressed() => (Keys)R.GetKeyPressed();
    }
}