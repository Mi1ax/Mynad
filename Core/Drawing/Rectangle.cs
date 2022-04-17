using System.Drawing;
using System.Numerics;

using static Raylib_CsLo.Raylib;
using RectangleRay = Raylib_CsLo.Rectangle;
using ColorSYS = System.Drawing.Color;
using ColorRAY = Raylib_CsLo.Color;

namespace Core.Drawing
{
    public class Rectangle
    {
        private RectangleRay _rectangle;
        private ColorRAY _color;
        private Vector2 _origin;
        private ColorRAY? _borderColor;

        public Vector2 Position
        {
            get => new (_rectangle.x, _rectangle.y);
            set
            {
                _rectangle.x = value.X;
                _rectangle.y = value.Y;
            }
        }

        public Vector2 Origin
        {
            get => _origin;
            set => _origin = value;
        }
        
        public Size Size
        {
            get => new ((int)_rectangle.width, (int)_rectangle.height);
            set
            {
                _rectangle.width = value.Width;
                _rectangle.height = value.Height;
            }
        }

        public Vector2 Center => new(
            _rectangle.x + _rectangle.width / 2, 
            _rectangle.y + _rectangle.height / 2);

        public ColorSYS FillColor
        {
            get => Utils.GetColorSysFromRay(_color);
            set => _color = Utils.GetColorRayFromSys(value);
        }

        public ColorSYS BorderColor
        {
            get => _borderColor != null ? Utils.GetColorSysFromRay(_borderColor.Value) : Color.Transparent;
            set => _borderColor = Utils.GetColorRayFromSys(value);
        }

        public float BorderThickness { get; init; }

        #region Contractors

        public Rectangle()
        {
            _rectangle = new RectangleRay();
        }

        public Rectangle(int x, int y, int width, int hieght)
        {
            _rectangle = new RectangleRay(x, y, width, hieght);
        }

        public Rectangle(Vector2 position, Size size)
        {
            _rectangle = new RectangleRay(
                position.X, position.Y, 
                size.Width, size.Height);
        }

        #endregion

        public void Draw()
        {
            DrawRectanglePro(_rectangle, _origin, 0f, _color);
            if (_borderColor != null)
                DrawRectangleLinesEx(
                    new RectangleRay(
                        _rectangle.x - _origin.X, 
                        _rectangle.y - _origin.Y,
                        _rectangle.width,
                        _rectangle.height
                        ), 
                    BorderThickness, _borderColor.Value);
        }
    }
}