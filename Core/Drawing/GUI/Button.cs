using System;
using System.Drawing;
using System.Numerics;
using Core.Drawing.Base;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;
using static Raylib_CsLo.RayGui;
using RectangleRay = Raylib_CsLo.Rectangle;

namespace Core.Drawing.GUI
{
    public class Button : IUiObject
    {
        private readonly string _text;
        private RectangleRay _rectangle;

        public Action OnButtonPressed { get; set; }

        public Vector2 Position
        {
            get => new(_rectangle.x, _rectangle.y);
            set
            {
                _rectangle.x = value.X;
                _rectangle.y = value.Y;
            }
        }

        public SizeF Size
        {
            get => new(_rectangle.width, _rectangle.height);
            set
            {
                _rectangle.width = value.Width;
                _rectangle.height = value.Height;
            }
        }

        public Button(Vector2 position, SizeF size, string text)
        {
            _text = text;
            _rectangle = new RectangleRay(position.X, position.Y, size.Width, size.Height);
        }
        
        public void Update(float deltaTime)
        {
            
        }

        public void Draw()
        {
            if (GuiButton(_rectangle, _text)) 
                OnButtonPressed?.Invoke();
        }
    }
}