using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_CsLo;

namespace Garbov
{

    class SoldierBarrack
    {
        public Vector2 position;
        Rectangle soldierBarrackRectangle;

        public bool placed = false;
        public bool canMove = true;

        int soldiers = 0;

        public SoldierBarrack(Vector2 position)
        {
            this.position = position;
        }

        public void Update()
        {
            this.soldierBarrackRectangle = new Rectangle(this.position.X, this.position.Y, 120, 120);

            if (placed)
            {
                canMove = false;
            }
        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(this.soldierBarrackRectangle, Raylib.PURPLE);
        }
    }
}
