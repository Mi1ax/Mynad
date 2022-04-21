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

        public bool IsIn(Vector2 position) => (position.X - Position.X) * (position.X - Position.X) +
            (position.Y - Position.Y) * (position.Y - Position.Y) <= Size * Size;

        public Circle(Vector2 position, float radius)
        {
            Position = position;
            Size = radius;
        }

        public override void Draw()
        {
            if (BorderColorRay != null)
            {
                DrawCircle((int) Position.X, (int) Position.Y, Size, BorderColorRay.Value);
                DrawCircle((int) Position.X, (int) Position.Y, Size - BorderThickness, ColorRay);
            }
            else DrawCircle((int)Position.X, (int)Position.Y, Size, ColorRay);
        }
    }
}