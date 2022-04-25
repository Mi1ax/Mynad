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
    public class CheckBox : IUiObject
    {
        private RectangleRay _rectangle;
        private RectangleRay _fullRect;
        private Vector2 _textSize;
        private string _text;
        private bool _isChecked;

        public bool Checked => _isChecked;

        public Vector2 Position
        {
            get => new (_fullRect.x, _fullRect.y);
            set
            {
                _fullRect.x = value.X - _textSize.X / 2;
                _fullRect.y = value.Y;
                _rectangle.x = _fullRect.x;
                _rectangle.y = _fullRect.y;
            }
        }
        public SizeF Size { get; set; }

        public CheckBox(Vector2 position, SizeF size, string text = "")
        {
            _text = text;
            Position = position;
            Size = size;
            _isChecked = false;
            _rectangle = new RectangleRay(position.X, position.Y, size.Width, size.Height);
            _textSize = MeasureTextEx(
                GuiGetFont(), 
                _text, 
                GuiGetStyle((int)GuiControl.DEFAULT, (int)GuiDefaultProperty.TEXT_SIZE), 2f);
            _fullRect = new RectangleRay(
                position.X, 
                position.Y, 
                _rectangle.width + _textSize.X, 
                _rectangle.height >= _textSize.Y ? _rectangle.height : _textSize.Y);
        }

        public void Update(float deltaTime)
        {
            
        }
        
        public void Draw()
        {
            _isChecked = GuiCheckBox(_rectangle, _text, _isChecked);
        }

        public IUiObject Copy() => MemberwiseClone() as CheckBox;
    }
}