using Garbov;
using Raylib_CsLo;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        Raylib.InitWindow(1920, 1080, "Garbov");
        Raylib.SetTargetFPS(60);
        Raylib.SetConfigFlags(ConfigFlags.FLAG_VSYNC_HINT);
        Raylib.ToggleFullscreen();

        Raylib.SetExitKey(0);

        List<Shooter> shooters = new List<Shooter>();

        Texture texture = Raylib.LoadTexture("background.png");
        Camera2D camera = new Camera2D();
        Vector2 cameraVector = new Vector2();
        Vector2 position = new Vector2();
        Vector2 previousMousePosition = Raylib.GetMousePosition();
        Vector2 currentMousePosition;

        Lists lists = new Lists();

        DialogueBox dialogueBox = new DialogueBox(new Vector2(480, 700));
        BuildingManager buildingManager = new BuildingManager();
        BuildingSelector buildingSelector = new BuildingSelector();

        ContentManager.LoadTextures();

        Shooter shooter = new Shooter(new Vector2(300, 300));
        shooters.Add(shooter);

        while (!Raylib.WindowShouldClose())
        {
            ContentManager.mouseToMapWorld = Raylib.GetScreenToWorld2D(Raylib.GetMousePosition(), camera);
            currentMousePosition = Raylib.GetMousePosition();
            position = Raylib.GetMousePosition();

            bool isMouseMoving = currentMousePosition != previousMousePosition;

            // Update previous mouse position
            previousMousePosition = currentMousePosition;

            Vector2.Normalize(cameraVector);

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                cameraVector.X -= 900 * Raylib.GetFrameTime();
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                cameraVector.X += 900 * Raylib.GetFrameTime();
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                cameraVector.Y -= 900 * Raylib.GetFrameTime();
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                cameraVector.Y += 900 * Raylib.GetFrameTime();
            }

            if (cameraVector.X <= 0) {
                cameraVector.X = 0;
            }
            if (cameraVector.X >= 602) {
                cameraVector.X = 602;
            }
            if (cameraVector.Y >= 1635) {
                cameraVector.Y = 1635;
            }
            if (cameraVector.Y <= 0) {
                cameraVector.Y = 0;
            }

            foreach(Shooter shooterK in shooters)
            {
                if (shooterK.isSelected)
                {
                    camera.target = shooterK.position;
                    camera.offset = new Vector2(900, 600);
                }

                else
                {
                    //dialogueBox.ChangeDialogue("Select a soldier to continue");
                    camera.offset = new Vector2(0, 0);
                    camera.target = cameraVector;

                    foreach (ShooterBullet sb in shooterK.shooterBullets)
                    {
                        if (sb.cameraFocus)
                        {
                            camera.offset = new Vector2(900, 600);
                            camera.target = sb.position;
                        }
                    }
                }
            }

            camera.zoom = 0.8f;

            Raylib.SetMouseCursor(3);

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.LIGHTGRAY);
            Raylib.BeginMode2D(camera);
            Raylib.DrawTexture(texture, 0, 0, Raylib.WHITE);
            Raylib.DrawText(Raylib.GetFPS().ToString(), 1000, 300, 60, Raylib.RED);

            shooter.Update();
            shooter.Draw();

            buildingManager.Update();

            foreach (SoldierBarrack soldierBarrack in buildingManager.lists.soldierBarracks)
            {
                soldierBarrack.Update();
                soldierBarrack.Draw();
            }


            Raylib.EndMode2D();
            dialogueBox.Update();
            dialogueBox.Draw();

            buildingSelector.Update();
            buildingSelector.Draw();

            Raylib.EndDrawing();
        }

        Raylib.UnloadTexture(texture);
        Raylib.CloseWindow();
    }
}
