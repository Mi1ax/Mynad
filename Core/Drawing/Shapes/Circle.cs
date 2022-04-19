using System.Numerics;
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

        public override void Draw()
        {
            DrawCircle((int)Position.X, (int)Position.Y, Size, ColorRay);
        }
    }
}