using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Garbov
{
    static class ContentManager
    {
        public static Texture mapTexture = new Texture();
        public static Texture dialogueBoxTexture = new Texture();
        public static Texture closeDialogueBoxTexture = new Texture();
        public static Vector2 mouseToMapWorld = new Vector2();
        public static bool aPlayerSelected = false;

        public static void LoadTextures()
        {
            mapTexture = Raylib.LoadTexture("background.png");
            dialogueBoxTexture = Raylib.LoadTexture("dialogueBox.png");
            closeDialogueBoxTexture = Raylib.LoadTexture("closeDialogueBox.png");
        }
    }
}
