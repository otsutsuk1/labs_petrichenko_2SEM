using System;
namespace App2
{
    class Program
    {
        static void Main(string[] args)
        {
            double x=0, y=0;
            try
            {
                Console.Write("Введіть х: ");
                x = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введіть y: ");
                y = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"\nx + y = {Calculator.Add(x, y)}");
                Console.WriteLine($"x - y = {Calculator.Sub(x, y)}");
                Console.WriteLine($"x * y = {Calculator.Multiply(x, y)}");
                Console.WriteLine($"x / y = {Calculator.Div(x, y)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nЩось пішло не так , перевірьте правильність введених даних\n{ex.Message}");
            }
        }
    }
}
