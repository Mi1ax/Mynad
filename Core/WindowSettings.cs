using System;
using System.Drawing;
using static Raylib_CsLo.Raylib;

namespace Core
{
    public struct WindowSettings
    {
        private string _title;
        private int _vWidth;
        private int _vHeight;
        private int _width;
        private int _height;

        public Action OnVirtualSizeChanged;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                SetWindowTitle(value);
            }
        }

        public int Width
        {
            get => _width;
            set
            {
                _width = value;
                SetWindowSize(_width, _height);
            }
        }

        public int Height
        {
            get => _height;
            set
            {
                _height = value;
                SetWindowSize(_width, _height);
            }
        }
        
        public Color Color { get; set; }

        public int VWidth
        {
            get => _vWidth == 0 ? Width : _vWidth;
            set
            {
                _vWidth = value;
                OnVirtualSizeChanged.Invoke();
            }
        }

        public int VHeight
        {
            get => _vHeight == 0 ? Height : _vHeight;
            set
            {
                _vHeight = value;
                OnVirtualSizeChanged.Invoke();
            }
        }

        public override string ToString()
        {
            return $"Window Title: \"{Title}\"; Resolution: {Width}:{Height}; Virtual Resolution: {VWidth}:{VHeight}";
        }
    }
}