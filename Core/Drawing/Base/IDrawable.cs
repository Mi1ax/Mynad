using System.Drawing;
using System.Numerics;

namespace Core.Drawing.Base
{
    public interface IDrawable
    {
        public Vector2 Position { get; set; }
        public SizeF Size { get; set; }

        public void Draw();
    }
}