using System.Drawing;

namespace Core
{
    public struct WindowSettings
    {
        private int _vWidth;
        private int _vHeight;
        
        public string Title { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        
        public Color Color { get; set; }

        public int VWidth
        {
            get => _vWidth == 0 ? Width : _vWidth;
            set => _vWidth = value;
        }

        public int VHeight
        {
            get => _vHeight == 0 ? Height : _vHeight;
            set => _vHeight = value;
        }

        public override string ToString()
        {
            return $"Window Title: \"{Title}\"; Resolution: {Width}:{Height}; Virtual Resolution: {VWidth}:{VHeight}";
        }
    }
}