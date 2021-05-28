using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Методи класу:

//замінити записану матрицю у файлі на іншу, якщо розмір нової матриці більший, записати її в кінець файлу;
//видалити матрицю;
//видалити з файлу пусті місця (дефрагментація);


namespace labwork_5_2
{
    class FileOperations
    {
        public Saver Saver { get; set; }
        Matrix matrix;
        public void Launch(Matrix matrix)
        {
            Saver = Saver.getInstance(matrix);
            this.matrix = matrix;
        }
        private string path = "matrix.txt";
        int matrixNumber=1;
        public void OpenFile()
        {
            if (File.Exists(path))
            {
                Console.WriteLine($"Файл {path} існує");
            }
            else
            {
                var myFile = File.Create(path);
                myFile.Close();
                Console.WriteLine($"Файл {path} ствоернний");
            }
        }
        public void WriteMatrix()
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"({matrixNumber})");
                for (int i = 0; i < matrix.Rows; i++)
                {
                    for (int j = 0; j < matrix.Columns; j++)
                    {
                        sw.Write(matrix.matrix[i, j] + "\t");
                    }
                    sw.WriteLine();
                }
                Console.WriteLine("Запис выконан");
            }
            matrixNumber++;
        }
        public void ReadMatrix(int matrix_number)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string line;
                int i=matrix.Rows;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == $"({matrix_number})" || (i<matrix.Rows&& i>=0))
                    {
                        Console.WriteLine(line);
                        i--;
                    }
                        
                    else
                        continue;
                }
            }
        }
        public void DeleteMatrix(int matrix_number)
        {
            string[] newString = new string[110];
            int j = 0;
            int i = 0;
            matrixNumber--;
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == $"({matrix_number})" || (i < matrix.Rows && i >= 0))
                    {
                        i--;
                    }

                    else
                    {
                        newString[j] = line;
                        j++;
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(path, false))
            {

                for (int k = 0; k < newString.Length; k++)
                {

                    sw.WriteLine(newString[k]);

                }

            }
            matrixNumber++;
        }
        public void ClearFile()
        {
            StreamWriter sr = new StreamWriter("matrix.txt", false);
            sr.WriteLine("");
            sr.Close();
            Console.WriteLine($"Файл {path} очищен");
        }
    }
}
