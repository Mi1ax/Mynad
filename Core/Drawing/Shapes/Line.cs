using System;
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
        
        public Line(Vector2 v1, Vector2 v2)
        {
            Color = ColorSYS.White;
            Thickness = 2;
            PositionFrom = v1;
            PositionTo = v2;
        }

        public Line(int x1, int y1, int x2, int y2)
        {
            Color = ColorSYS.White;
            Thickness = 2;
            PositionFrom = new Vector2(x1, y1);
            PositionTo = new Vector2(x2, y2);
        }

        public bool IsIn(Vector2 position, float thickness = 6f)
        {
            var m = (PositionTo.Y - PositionFrom.Y) / (PositionTo.X - PositionFrom.X);
            var c = PositionTo.Y - (m * PositionTo.X);
            return position.X >= Math.Min(PositionFrom.X, PositionTo.X)
                   && position.X <= Math.Max(PositionFrom.X, PositionTo.X)
                   && position.Y >= Math.Min(PositionFrom.Y, PositionTo.Y)
                   && position.Y <= Math.Max(PositionFrom.Y, PositionTo.Y)
                   && Math.Abs(Math.Abs(position.Y) - Math.Abs((m * position.X) + c)) < thickness;
        }

        public void Draw()
        {
            Raylib.DrawLineEx(PositionFrom, PositionTo, Thickness, _color);
        }
    }
}