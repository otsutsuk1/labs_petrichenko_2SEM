using System;
using System.Collections.Generic;
using System.Text;

namespace Task7
{
    class Scout
    {
        public Scout(string Name)
        {
            this.Name = Name;
            Position = new Point(rand.Next(0, 9), rand.Next(0, 9));
        }
        public Point Position { get; set; }
        public string Name { get; set; }
        private Random rand;

    }
}
