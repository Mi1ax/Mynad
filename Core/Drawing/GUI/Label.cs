using System.Drawing;
using System.Numerics;
using Core.Drawing.Base;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;
using static Raylib_CsLo.RayGui;
using RectangleRay = Raylib_CsLo.Rectangle;
using ColorRAY = Raylib_CsLo.Color;
using ColorSYS = System.Drawing.Color;
using Rectangle = Core.Drawing.Shapes.Rectangle;

namespace Core.Drawing.GUI
{
    public class Label : IUiObject
    {
        private string _text;
        private RectangleRay _rectangle;
        private Font _font;
        private Vector2 _textSize;
        private ColorRAY _color = BLACK;

        public float FSize { get; }

        public string Text
        {
            get => _text;
            set => _text = value;
        }

        public bool IsCenter { get; set; }

        public Rectangle Rectangle
        {
            get => new(_rectangle.x, _rectangle.y, _rectangle.width, _rectangle.height);
            set
            {
                _rectangle.x = value.Position.X;
                _rectangle.y = value.Position.Y;
                _rectangle.width = value.Size.Width;
                _rectangle.height = value.Size.Height;
            }
        }

        public Vector2 Position
        {
            get => new (_rectangle.x, _rectangle.y);
            set
            {
                if (IsCenter)
                {
                    _rectangle.x = value.X - Size.Width / 2;
                    _rectangle.y = value.Y - Size.Height / 2;
                }
                else
                {
                    _rectangle.x = value.X;
                    _rectangle.y = value.Y;
                }
            }
        }

        public SizeF Size
        {
            get => new (_rectangle.width, _rectangle.height);
            set
            {
                _rectangle.width = value.Width;
                _rectangle.height = value.Height;
            }
        }

        public ColorSYS Color
        {
            get => Utils.GetColorSysFromRay(_color);
            set => _color = Utils.GetColorRayFromSys(value);
        }
        
        public Label(string text, float? fontSize = null)
        {
            _text = text;
            FSize = fontSize ?? FontSize.Big;
            InitRectangle();
        }

        public Label()
        {
            _text = "";
            InitRectangle();
        }
        
        private void InitRectangle() 
        {
            _font = GetFontDefault();
            _textSize = MeasureTextEx(_font, _text, FSize, 2f);
            _rectangle = new RectangleRay(0, 0, _textSize.X, _textSize.Y);
        }
        
        public void Update(float deltaTime)
        {
            
        }

        public void Draw()
        {
            DrawTextEx(_font, _text, new Vector2(_rectangle.x, _rectangle.y), FSize, 2f, _color);
        }
    }
}