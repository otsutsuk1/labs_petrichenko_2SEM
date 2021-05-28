using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labwork_5_2
{
    class Saver
    {
        private static Saver instance;

        public Matrix matrix { get; private set; }

        protected Saver(Matrix matrix)
        {
            this.matrix = matrix;
        }

        public static Saver getInstance(Matrix matrix)
        {
            if (instance == null)
                instance = new Saver(matrix);
            return instance;
        }
        
    }
}
