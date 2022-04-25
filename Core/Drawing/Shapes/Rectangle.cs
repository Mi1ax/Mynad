using System.Drawing;
using System.Numerics;
using Core.Drawing.Base;
using static Raylib_CsLo.Raylib;
using RectangleRay = Raylib_CsLo.Rectangle;

namespace Core.Drawing.Shapes
{
    public class Rectangle : Shape
    {
        #region Contractors

        public Rectangle()
        {
            BorderThickness = 1;
        }

        public Rectangle(float x, float y, float width, float height)
        {
            BorderThickness = 1;
            Position = new Vector2(x, y);
            Size = new SizeF(width, height);
        }

        public Rectangle(Vector2 position, SizeF size)
        {
            BorderThickness = 1;
            Position = position;
            Size = size;
        }

        #endregion
        
        public override void Draw()
        {
            DrawRectanglePro(
                new RectangleRay(Position.X, Position.Y, Size.Width, Size.Height), 
                Origin, 0f, ColorRay);
            if (BorderColor != Color.Transparent && BorderColorRay != null)
                DrawRectangleLinesEx(new RectangleRay(Position.X, Position.Y, Size.Width, Size.Height), 
                    BorderThickness, BorderColorRay.Value);
        }

        public Rectangle Copy() => MemberwiseClone() as Rectangle;
    }
}