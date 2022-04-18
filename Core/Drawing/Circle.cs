using System.Drawing;
using System.Numerics;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;
using ColorSYS = System.Drawing.Color;
using ColorRAY = Raylib_CsLo.Color;

namespace Core.Drawing
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
        
        public void Draw()
        {
            DrawCircle((int)Position.X, (int)Position.Y, Size, ColorRay);
        }
    }
}