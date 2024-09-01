using System;
using System.Collections.Generic;
using Raylib_CsLo;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbov
{
    class BuildingSelector
    {
        Rectangle soldierBarrackButton = new Rectangle(550, 760, 200, 200);
        Rectangle soldierBarrackImage = new Rectangle(600, 810, 100, 100);

        public Building buildingSelected;
        public BuildingSelector()
        {

        }

        public void Update()
        {
            Rectangle mouseRect = new Rectangle(Raylib.GetMouseX(), Raylib.GetMouseY(), 16, 16);

            if (Raylib.CheckCollisionRecs(mouseRect, soldierBarrackButton))
            {
                buildingSelected = Building.SoldierBarrack;
            }
        }

        public void Draw()
        {
            Rectangle mouseRect = new Rectangle(Raylib.GetMouseX(), Raylib.GetMouseY(), 16, 16);

            if (Raylib.CheckCollisionRecs(mouseRect, soldierBarrackButton))
            {
                
                Raylib.DrawRectangleRec(soldierBarrackButton, Raylib.LIGHTGRAY);
                
            }

            else
            {
                Raylib.DrawRectangleRec(soldierBarrackButton, Raylib.WHITE);
            }

            Raylib.DrawRectangleRec(soldierBarrackImage, Raylib.PURPLE);
        }

        public enum Building
        {
            SoldierBarrack
        }
    }
}

