using System;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowGCD(156,12);
        }

        private static void ShowGCD(int x, int y)
        {
            while (true)
            {
                if (x != y)
                {
                    if (x > y)
                        x -= y;
                    else
                        y -= x;
                }
                else
                {
                    Console.WriteLine(x);
                    break;
                }
            }
        }
    }
}
