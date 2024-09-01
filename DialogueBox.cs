using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Garbov
{
    class DialogueBox
    {
        Vector2 position;
        string dialogue = "";
        public DialogueBox(Vector2 position) {
            this.position = position;
        }

        public void ChangeDialogue(string dialogue)
        {
            this.dialogue = dialogue;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            Raylib.DrawTexture(ContentManager.dialogueBoxTexture, 480, 700, Raylib.WHITE);
            Raylib.DrawText(dialogue, 540, 740, 60, Raylib.BLACK);
        }
    }
}
