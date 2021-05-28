using System;

namespace App1
{
    delegate double Average(int x, int y, int z);
    
    class Program
    {
        static void Main(string[] args)
        {
            int x, y, z;
            try
            {
                Console.Write("Введіть х: ");
                x = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введіть y: ");
                y = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введіть z: ");
                z = Convert.ToInt32(Console.ReadLine());
                Average avg = delegate(int x, int y, int z) { return (double)(x + y + z) / 3d; };
                Console.WriteLine($"\nсереднье арифметичне число {x},{y},{z} = {avg(x,y,z)}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Щось пішло не так , перевірте правильне написання чисел\n{ex.Message}");
            }
        }
    }
}
