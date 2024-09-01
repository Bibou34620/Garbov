
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_CsLo;

namespace Garbov
{
    class BuildingManager
    {
        BuildingSelector buildingSelector = new BuildingSelector();

        public bool isBuildingEnabled;
        public int playerBuilder = 1;

        public Lists lists = new Lists();

        public BuildingManager()
        {

        }

        public void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_B))
            {
                isBuildingEnabled = true;
            }

            if (isBuildingEnabled)
            {
                if(buildingSelector.buildingSelected == BuildingSelector.Building.SoldierBarrack)
                {
                    SoldierBarrack sbPlacement = new SoldierBarrack(new System.Numerics.Vector2(ContentManager.mouseToMapWorld.X, ContentManager.mouseToMapWorld.Y));

                    if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT))
                    {
                        sbPlacement.placed = true;
                        Vector2 soldierBarrackPosition = sbPlacement.position;
                        SoldierBarrack soldierBarrack = new SoldierBarrack(soldierBarrackPosition);

                        lists.soldierBarracks.Add(soldierBarrack);
                    }

                    sbPlacement.Update();
                    sbPlacement.Draw();
                }
            }
        }
    }
}
