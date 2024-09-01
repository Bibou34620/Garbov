using Raylib_CsLo;
using System.Numerics;

namespace Garbov
{
    class ShooterBullet
    {
        public Vector2 position;
        public Vector2 direction;
        public float speed = 500f;
        public bool isActive = true;
        public bool cameraFocus = true;
        public bool canDestroyBullet = false;

        public float lifeTime = 3f;
        float timerToKillBullet;

        Color pixelColor;
        bool queuedToDestory = false;
        Image mapImage;
        float destroyTime = 1f;
        float timer;

        public ShooterBullet(Vector2 position, Vector2 direction)
        {
            this.position = position;
            this.direction = Vector2.Normalize(direction);
            mapImage = Raylib.LoadImageFromTexture(ContentManager.mapTexture);
            pixelColor = Raylib.GetImageColor(mapImage, (int)position.X, (int)position.Y);
        }

        public void Update()
        {
            timerToKillBullet += 1 * Raylib.GetFrameTime();

            if (isActive)
            {
                position += direction * speed * Raylib.GetFrameTime();
            }

            pixelColor = Raylib.GetImageColor(mapImage, (int)position.X, (int)position.Y);
            bool isColliding = pixelColor.r == 255 && pixelColor.g == 255 && pixelColor.b == 255;

            if (isColliding)
            {
                isActive = false;
                queuedToDestory = true;
            }

            if (timerToKillBullet >= lifeTime)
            {
                isActive = false;
                queuedToDestory = true;
            }

            if (queuedToDestory)
            {
                timer += 1 * Raylib.GetFrameTime();

                if(timer >= destroyTime)
                {
                    cameraFocus = false;
                    canDestroyBullet = true;
                }
            }
        }

        public void Draw()
        {
            if (isActive)
            {
                Raylib.DrawCircleV(position, 10, Raylib.RED);
            }
        }
    }
}
