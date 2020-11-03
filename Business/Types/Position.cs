using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace hb.Business.Types
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Enums.Direction Direction { get; private set; }

        public Position(int x, int y, Enums.Direction direction)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }

        public void MoveForward()
        {
            switch (Direction)
            {
                case Enums.Direction.N:
                    Y++;
                    break;
                case Enums.Direction.S:
                    Y--;
                    break;
                case Enums.Direction.E:
                    X++;
                    break;
                case Enums.Direction.W:
                    X--;
                    break;
            }
        }

        public void MoveRight()
        {
            this.Direction = (Enums.Direction)(((int)++this.Direction + 4) % 4);
        }

        public void MoveLeft()
        {
            this.Direction = (Enums.Direction)(((int)--this.Direction + 4) % 4);
        }
    }
}
