using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

using Core.Drawing.Base;

using Raylib_CsLo;
using static Raylib_CsLo.Raylib;
using static Raylib_CsLo.RayGui;
using RectangleRay = Raylib_CsLo.Rectangle;

namespace Core.Drawing.GUI
{
    public class Panel : IUpdatable, IDrawable
    {
        private readonly Window _baseWindow;
        private readonly List<IUiObject> _objects;

        private RectangleRay _rectangle;

        public Margin Margin
        {
            init
            {
                _rectangle.x = value.Left;
                _rectangle.y = value.Top;
                _rectangle.width -= value.Left + value.Right;
                _rectangle.height -= value.Top + value.Bottom;
            }
        }

        public Vector2 Padding { get; set; }

        public Vector2 Position
        {
            get => new (_rectangle.x, _rectangle.y);
            set
            {
                _rectangle.x = value.X;
                _rectangle.y = value.Y;
                SetObjectPosition();
            }
        }

        public SizeF Size
        {
            get => new (_rectangle.width, _rectangle.height);
            set
            {
                _rectangle.width = value.Width;
                _rectangle.height = value.Height;
                SetObjectPosition();
            }
        }
        
        public Panel(Window baseWindow, SizeF? size = null)
        {
            _baseWindow = baseWindow;
            _rectangle = size == null 
                ? new RectangleRay(0, 0, _baseWindow.GetSettings().VWidth, _baseWindow.GetSettings().VHeight) 
                : new RectangleRay(0, 0, size.Value.Width, size.Value.Height);
            _objects = new List<IUiObject>();
            SetObjectPosition();
        }

        private void SetObjectPosition()
        {
            for (var i = 0; i < _objects.Count; i++)
            {
                if (i == 0)
                {
                    _objects[i].Position = new Vector2(
                        _rectangle.x + _rectangle.width / 2f - _objects[i].Size.Width / 2f, 
                        _rectangle.y + Padding.Y);
                    continue;
                }

                _objects[i].Position = new Vector2(
                    _rectangle.x + _rectangle.width / 2 - _objects[i].Size.Width / 2,
                    _objects[i - 1].Position.Y + _objects[i - 1].Size.Height + Padding.Y);
            }
        }

        private void Add(IUiObject uiObject)
        {
            _objects.Add(uiObject);
        }

        public void Add(params IUiObject[] uiObjects)
        {
            foreach (var uiObject in uiObjects)
                _objects.Add(uiObject);
            SetObjectPosition();
        }

        public void Update(float deltaTime)
        {
            _objects.ForEach(o => o.Update(deltaTime));
        }

        public void Draw()
        {
            GuiPanel(_rectangle);
            _objects.ForEach(o => o.Draw());
        }
    }
}