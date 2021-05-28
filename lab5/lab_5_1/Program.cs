using System;

namespace labwork_5_1
{
    class Program
    {
        static int rows, columns;
        static void Main(string[] args)
        {
            //основная матрица
            EnterValues();
            Matrix matrix = new Matrix(rows,columns);
            matrix.CreateMatrix();

            Console.WriteLine("Создана матриця: "); 
            matrix.PrintMatrix();

            Console.WriteLine($"Детерминант матриці: {matrix.CalculateDeterminant()}");

            Console.WriteLine("\nТранспонована матриця:");
            matrix.CreateTransposeMatrix().PrintMatrix();

            Console.WriteLine("\Зворотьня матриця:");
            matrix.CreateInverseMatrix().PrintMatrix();

            //матрица В
            EnterValues();
            Matrix matrix2 = new Matrix(rows, columns);
            matrix2.CreateMatrix();
            Console.WriteLine("Создана матриця: ");
            matrix2.PrintMatrix();

            //умножение
            Console.WriteLine("\nРезультат умножения первой матрицы на вторую");
            matrix.MultiplyMatrix(matrix2).PrintMatrix();
        }
        public static void EnterValues()
        {
            do
            {
                Console.Write("Введіть кілкість строк: ");
                rows = int.Parse(Console.ReadLine());
                Console.Write("Введіть кількисть колонок: ");
                columns = int.Parse(Console.ReadLine());
                Console.WriteLine();
                if (rows <= 0 || columns <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Введіть значення більше 0\n");
                    Console.ResetColor();
                }
            }
            while (rows <= 0 || columns <= 0);
        }
    }
}
