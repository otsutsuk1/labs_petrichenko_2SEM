using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labwork_5_1
{
    class Matrix
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public  double[,] matrix;
        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            matrix = new double[rows, columns];
            ProcessFunctionOverData((i, j) => matrix[i, j] = 0);
        }

        public void CreateMatrix()
        {
            Random rand = new Random(); 
            for (int i = 0; i < Rows; i++) 
            {
                for (int j = 0; j < Columns; j++)
                {
                    matrix[i, j] = rand.Next(-20, 21); 
                }
            }
        }
        public void PrintMatrix()   
        {
            for (int i = 0; i < Rows; i++) 
            {
                for (int j = 0; j < Columns; j++) 
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }

        }
        public bool IsSquare() 
        {
            if (Rows == Columns)
                return true;
            else
                return false;
        }
        public void ProcessFunctionOverData(Action<int, int> func)
        {
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    func(i, j);
                }
            }
        }
        private Matrix CreateMatrixWithoutColumn(int column)
        {
            if (column < 0 || column >= Columns)
            {
                Console.WriteLine("Помилка індекса колонки");
            }
            Matrix result = new Matrix(Rows, Columns - 1);
            result.ProcessFunctionOverData((i, j) =>
                result.matrix[i, j] = j < column ? matrix[i, j] : matrix[i, j + 1]);
            return result;
        }
        private Matrix CreateMatrixWithoutRow(int row)
        {
            if (row < 0 || row >= Rows)
            {
                Console.WriteLine("Помилка індекса строчки");
            }
            var result = new Matrix(Rows - 1, Columns);
            result.ProcessFunctionOverData((i, j) =>
                result.matrix[i, j] = i < row ? matrix[i, j] : matrix[i + 1, j]);
            return result;
        }
        public double CalculateDeterminant()
        {
            if (IsSquare() == false)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Детерминант вичесляется тільки для квадратної матриці");
                Console.ResetColor();
                return double.PositiveInfinity;
            }
            else if (Columns == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            double result = 0;
            for (var j = 0; j < Columns; j++)
            {
                result += (j % 2 == 1 ? 1 : -1) * matrix[1, j] *
                    this.CreateMatrixWithoutColumn(j).
                    CreateMatrixWithoutRow(1).CalculateDeterminant();
            }
            return result;
        }
        public Matrix CreateTransposeMatrix()
        {
            Matrix result = new Matrix(Columns, Rows);
            result.ProcessFunctionOverData((i, j) => result.matrix[i, j] = matrix[j, i]);
            return result;
        }
        public Matrix CreateInverseMatrix()
        {
            if (Rows != Columns)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Зворотній матриця існує тільки для квадратної");
                Console.ResetColor();
                Matrix result = new Matrix(0,0);
                return result;
            }

            else
            {
                double determinant = CalculateDeterminant();

                Matrix result = new Matrix(Rows, Rows);
                ProcessFunctionOverData((i, j) =>
                {
                    result.matrix[i, j] = ((i + j) % 2 == 1 ? -1 : 1) * CalculateMinor(i, j) / determinant;
                });

                result = result.CreateTransposeMatrix();
                return result;
            }
        }

        private double CalculateMinor(int i, int j)
        {
            return CreateMatrixWithoutColumn(j).CreateMatrixWithoutRow(i).CalculateDeterminant();
        }

        public Matrix MultiplyMatrix(Matrix matrix2)
        {
            if (Columns != matrix2.Rows)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Дані матриці не можна перемножити");
                Console.ResetColor();
                Matrix result = new Matrix(0, 0);
                return result;
            }
            else
            {
                Matrix result = new Matrix(Rows, matrix2.Columns);
                result.ProcessFunctionOverData((i, j) =>
                {
                    for (int k = 0; k < Rows; k++)
                    {
                        result.matrix[i, j] += matrix[i, k] * matrix2.matrix[k, j];
                    }
                });
                return result;
            }
            
        }
    }
}
