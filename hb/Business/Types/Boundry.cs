using System;
using System.Collections.Generic;
using System.Text;

namespace hb.Business.Types
{
    public class Boundry
    {

        public int X { get; private set; }
        public int Y { get; private set; }

        public Boundry(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
