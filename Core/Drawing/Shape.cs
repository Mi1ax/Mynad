using System.Drawing;
using System.Numerics;

using static Raylib_CsLo.Raylib;
using RectangleRay = Raylib_CsLo.Rectangle;
using ColorSYS = System.Drawing.Color;
using ColorRAY = Raylib_CsLo.Color;

namespace Core.Drawing
{
    public abstract class Shape
    {
        protected ColorRAY ColorRay;
        protected ColorRAY? BorderColorRay;
        
        public Vector2 Position { get; set; }
        public Vector2 Origin { get; set; }
        public SizeF Size { get; set; }

        public Vector2 Center => new(
            Position.X + Size.Width / 2f, 
            Position.Y + Size.Height / 2f);

        public ColorSYS FillColor
        {
            get => Utils.GetColorSysFromRay(ColorRay);
            set => ColorRay = Utils.GetColorRayFromSys(value);
        }

        public ColorSYS BorderColor
        {
            get => BorderColorRay != null ? Utils.GetColorSysFromRay(BorderColorRay.Value) : Color.Transparent;
            set => BorderColorRay = Utils.GetColorRayFromSys(value);
        }

        public float BorderThickness { get; init; }

        protected Shape()
        {
            Position = Vector2.Zero;
            Size = SizeF.Empty;
            Origin = Vector2.Zero;
            BorderColor = Color.Transparent;
            FillColor = Color.Transparent;
        }
    }
}