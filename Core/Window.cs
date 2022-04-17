using System.Numerics;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;
using static Raylib_CsLo.RayGui;

namespace Core
{
    public abstract class Window
    {
        protected static bool IsMouseButtonPressed(Input.MouseButton mouseButton) =>
            Raylib.IsMouseButtonPressed((int)mouseButton);

        protected static Vector2 GetMousePosition() =>
            Raylib.GetMousePosition();
        
        protected WindowSettings Settings;
        
        protected Window()
        {
            Settings = new WindowSettings()
            {
                Title = "Default Title",
                Width = 1280,
                Height = 720,
                Color = Utils.GetColorSysFromRay(RAYWHITE)
            };
            InitWindow(Settings.Width, Settings.Height, Settings.Title);
            SetTargetFPS(75);
            GuiLoadStyleDefault();
        }
        
        protected abstract void Update(float deltaTime);
        protected abstract void Draw();

        public void Run()
        {
            while (!WindowShouldClose())
            {
                Update(GetFrameTime());
                BeginDrawing();
                ClearBackground(Utils.GetColorRayFromSys(Settings.Color));
                Draw();
                EndDrawing();
            }
            CloseWindow();
        }
    }
}