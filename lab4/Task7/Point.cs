using System;
using System.Collections.Generic;
using System.Text;

namespace Task7
{
    class Point
    {
        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public void Up () => this.Y += -1;
        public void Down() => this.Y += +1;
        public void Left() => this.X += -1;
        public void Right() => this.X += +1;

    }
}
