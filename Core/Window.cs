using System;
using System.Collections.Generic;
using System.Numerics;
using Raylib_CsLo;
using static Raylib_CsLo.Raylib;
using static Raylib_CsLo.RayGui;

namespace Core
{
    public abstract class Window
    {
        public static readonly Dictionary<string, Font> Fonts = new ();

        protected static bool IsMouseButtonPressed(Input.MouseButton mouseButton) =>
            Raylib.IsMouseButtonPressed((int)mouseButton);

        protected static Vector2 GetMousePosition() =>
            Raylib.GetMousePosition();

        protected static void SetTargetFPS(int fps) =>
            Raylib.SetTargetFPS(fps);
        
        protected static int GetFPS() => 
            Raylib.GetFPS();
        
        protected WindowSettings Settings;
        
        private RenderTexture _target;
        private bool _isRunning;
        private int _scale;
        
        protected Window()
        {
            Settings = new WindowSettings()
            {
                Title = "Default Title",
                Width = 1280,
                Height = 720,
                Color = Utils.GetColorSysFromRay(RAYWHITE),
                OnVirtualSizeChanged = InitVirtualSize
            };
            InitWindow(Settings.Width, Settings.Height, Settings.Title);
            SetTargetFPS(75);
            GuiLoadStyleDefault();
            GuiSetStyle((int)GuiControl.DEFAULT, (int)GuiDefaultProperty.TEXT_SIZE, 20);
            InitVirtualSize();
            _isRunning = true;
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

        public void Close() => _isRunning = false;
        
        protected abstract void Update(float deltaTime);
        protected abstract void Draw();

        public void Run()
        {
            while (!WindowShouldClose() && _isRunning)
            {
                Update(GetFrameTime());
                BeginTextureMode(_target);
                ClearBackground(Utils.GetColorRayFromSys(Settings.Color));
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

            foreach (var (_, font) in Fonts)
                UnloadFont(font);
            
            UnloadTexture(_target.texture);
            CloseWindow();
        }
    }
}