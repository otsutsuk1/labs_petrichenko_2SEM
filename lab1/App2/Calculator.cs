using System;
using System.Collections.Generic;
using System.Text;

namespace App2
{
    public delegate double Operation(double x, double y);
    class Calculator
    {
        public static Operation Add = (x, y) => x + y;
        public static Operation Sub = (x, y) => x - y;
        public static Operation Multiply = (x, y) => x * y;

        public static Operation Div = (x, y) =>
        {
            if (y != 0)
            {
                return x / y;
            }
            else
            {
                throw new Exception("Помилка , ділення на 0");
            }
        };
    }
}
