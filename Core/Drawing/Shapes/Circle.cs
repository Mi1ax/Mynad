using System.Numerics;
using Core.Drawing.Base;
using static Raylib_CsLo.Raylib;

namespace Core.Drawing.Shapes
{
    public class Circle : Shape
    {
        public new float Size { get; set; }
        
        public Circle() { }

        public Circle(float x, float y, float radius)
        {
            Position = new Vector2(x, y);
            Size = radius;
        }

        public Circle(Vector2 position, float radius)
        {
            Position = position;
            Size = radius;
        }
        
        public bool IsIn(Vector2 position) => (position.X - Position.X) * (position.X - Position.X) +
            (position.Y - Position.Y) * (position.Y - Position.Y) <= Size * Size;

        public override void Draw()
        {
            if (BorderColorRay != null)
            {
                DrawCircleV(Position, Size, BorderColorRay.Value);
                DrawCircleV(Position, Size - BorderThickness, ColorRay);
            }
            else DrawCircleV(Position, Size, ColorRay);
        }
    }
}