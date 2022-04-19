using System.Drawing;

namespace Core
{
    public struct WindowSettings
    {
        public string Title { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int VWidth { get; set; }
        public int VHeight { get; set; }
        public Color Color { get; set; }

        public override string ToString()
        {
            return $"Window Title: \"{Title}\"; Resolution: {Width}:{Height}; Virtual Resolution: {VWidth}:{VHeight}";
        }
    }
}