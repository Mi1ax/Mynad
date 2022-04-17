using System.Drawing;
using System.Numerics;
using Core;
using Core.Drawing;
using Core.Input;
using Rectangle = Core.Drawing.Rectangle;

namespace Sandbox
{
    public class App : Window
    {
        private readonly Rectangle _rectangle;
        private readonly Line _line;
        
        public App()
        {
            Settings.Title = "App";
            Settings.Color = Color.Black;

            _rectangle = new Rectangle
            {
                Position = new Vector2(10, 10),
                Size = new Size(64, 64),
                FillColor = Color.White,
                BorderColor = Color.Chocolate,
                BorderThickness = 3f
            };
            _line = new Line(0, 0, 0, 0)
            {
                Thickness = 2,
                Color = Color.Wheat
            };
        }
        
        protected override void Update(float deltaTime)
        {
            if (IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            {
                _line.PositionFrom = _rectangle.Center;
                _line.PositionTo = GetMousePosition();
            }
        }

        protected override void Draw()
        {
            _line.Draw();
            _rectangle.Draw();
        }
    }
}