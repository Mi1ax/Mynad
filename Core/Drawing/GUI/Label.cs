using System.Drawing;
using System.Numerics;
using Core.Drawing.Base;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;
using static Raylib_CsLo.RayGui;
using RectangleRay = Raylib_CsLo.Rectangle;

namespace Core.Drawing.GUI
{
    public class Label : IUiObject
    {
        private string _text;
        private RectangleRay _rectangle;
        private Font _font;
        private float _fontSize;
        private Vector2 _textSize;

        public Vector2 Position
        {
            get => new (_rectangle.x, _rectangle.y);
            set
            {
                _rectangle.x = value.X;
                _rectangle.y = value.Y;
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

        public Label(string text, float? fontSize = null)
        {
            _text = text;
            _fontSize = fontSize ?? FontSize.Big;
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
            _textSize = MeasureTextEx(_font, _text, _fontSize, 2f);
            _rectangle = new RectangleRay(0, 0, _textSize.X, _textSize.Y);
        }
        
        public void Update(float deltaTime)
        {
            
        }

        public void Draw()
        {
            DrawTextEx(_font, _text, new Vector2(_rectangle.x, _rectangle.y), _fontSize, 2f, BLACK);
        }
    }
}