using System;

namespace labwork_5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(4,4);

            matrix.CreateMatrix();

            FileOperations fileOperations = new FileOperations();
            fileOperations.Launch(matrix);

            fileOperations.OpenFile();
            fileOperations.WriteMatrix();
            fileOperations.ReadMatrix(1);

            fileOperations.DeleteMatrix(1);
        }
    }
}
