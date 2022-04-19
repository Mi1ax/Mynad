using System.Numerics;
using Raylib_CsLo;
using ColorRAY = Raylib_CsLo.Color;
using ColorSYS = System.Drawing.Color;

namespace Core.Drawing.Shapes
{
    public class Line
    {
        private ColorRAY _color;

        public int Thickness { get; set; }
        public Vector2 PositionTo { get; set; }
        public Vector2 PositionFrom { get; set; }

        public ColorSYS Color
        {
            get => Utils.GetColorSysFromRay(_color);
            set => _color = Utils.GetColorRayFromSys(value);
        }

        public Line(int x1, int y1, int x2, int y2)
        {
            PositionFrom = new Vector2(x1, y1);
            PositionTo = new Vector2(x2, y2);
        }

        public void Draw()
        {
            Raylib.DrawLineEx(PositionFrom, PositionTo, Thickness, _color);
        }
    }
}