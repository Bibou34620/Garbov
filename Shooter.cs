using Raylib_CsLo;
using System;
using System.Numerics;

namespace Garbov
{
    class Shooter
    {
        public Vector2 position;
        Vector2 previousPosition;
        Rectangle shooterRect;
        public bool isSelected = false;
        bool isMoving = false;
        float updateCollisionTime = 1f;
        float updateTimer;
        Color pixelColor;
        Image mapImage;

        public Shooter(Vector2 position)
        {
            this.position = position;
            this.previousPosition = this.position;
            mapImage = Raylib.LoadImageFromTexture(ContentManager.mapTexture);
            pixelColor = Raylib.GetImageColor(mapImage, (int)position.X, (int)position.Y);
        }

        public void Update()
        {
            Rectangle mouseRect = new Rectangle(ContentManager.mouseToMapWorld.X + 16, ContentManager.mouseToMapWorld.Y + 16, 16, 16);
            this.shooterRect = new Rectangle(this.position.X, this.position.Y, 64, 64);
            updateTimer += 1 * Raylib.GetFrameTime();

            if (isSelected)
            {
                ContentManager.aPlayerSelected = true;
                previousPosition = position;
                Vector2 newPosition = position;

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
                {
                    isSelected = false;
                }


                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                {
                    newPosition.X -= 300 * Raylib.GetFrameTime();
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    newPosition.X += 300 * Raylib.GetFrameTime();
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                {
                    newPosition.Y -= 300 * Raylib.GetFrameTime();
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                {
                    newPosition.Y += 300 * Raylib.GetFrameTime();
                }

                pixelColor = Raylib.GetImageColor(mapImage, (int)newPosition.X, (int)newPosition.Y);
                bool isColliding = pixelColor.r == 255 && pixelColor.g == 255 && pixelColor.b == 255;

                if (!isColliding)
                {
                    position = newPosition;
                }
                else
                {
                    Raylib.DrawText("Collision Detected", 0, 0, 20, Raylib.RED);
                }
            }

            else
            {
                if (Raylib.CheckCollisionRecs(shooterRect, mouseRect))
                {
                    if(Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
                        isSelected = true;
                }
            }
        }

        public void Draw()
        {
            float angle = 0f;
            if (isSelected)
            {
                angle = MathF.Atan2(ContentManager.mouseToMapWorld.Y - position.Y, ContentManager.mouseToMapWorld.X - position.X) * (180 / MathF.PI);
            }
                
            Raylib.DrawRectanglePro(shooterRect, new Vector2(32, 32), angle, Raylib.RED);

            Raylib.DrawText(angle.ToString(), 500, 0, 20, Raylib.RED);
        }
    }
}
