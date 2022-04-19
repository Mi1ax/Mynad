using System;
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
        
        private RenderTexture _target;
        private int _scale;
        
        protected Window()
        {
            Settings = new WindowSettings()
            {
                Title = "Default Title",
                Width = 1280,
                Height = 720,
                VWidth = 1280 / 2,
                VHeight = 720 / 2,
                Color = Utils.GetColorSysFromRay(RAYWHITE)
            };
            InitWindow(Settings.Width, Settings.Height, Settings.Title);
            SetTargetFPS(75);
            GuiLoadStyleDefault();
            InitVirtualSize();
        }
        
        private void InitVirtualSize() 
        {
            _target = LoadRenderTexture(Settings.VWidth, Settings.VHeight);
            _scale = Math.Min(
                Settings.Width / Settings.VWidth, 
                Settings.Height / Settings.VHeight);
            
            SetMouseOffset(
                -(Settings.Width - Settings.VWidth * _scale) / 2, 
                -(Settings.Height - Settings.VHeight * _scale) / 2);
            SetMouseScale(1f / _scale, 1f / _scale);
        }

        public WindowSettings GetSettings() => Settings; 
        
        protected abstract void Update(float deltaTime);
        protected abstract void Draw();

        public void Run()
        {
            while (!WindowShouldClose())
            {
                Update(GetFrameTime());
                BeginTextureMode(_target);
                ClearBackground(BLACK);
                Draw();
                EndTextureMode();
                
                BeginDrawing();
                ClearBackground(BLACK);
                DrawTexturePro(_target.texture, 
                    new Rectangle(0.0f, 0.0f, _target.texture.width, -_target.texture.height),
                    new Rectangle(
                        (Settings.Width - Settings.VWidth * _scale) * 0.5f, 
                        (Settings.Height - Settings.VHeight * _scale) * 0.5f,
                        Settings.VWidth * _scale, 
                        Settings.VHeight * _scale), 
                    new Vector2(0, 0), 
                    0.0f, 
                    WHITE);
                EndDrawing();
            }
            UnloadTexture(_target.texture);
            CloseWindow();
        }
    }
}