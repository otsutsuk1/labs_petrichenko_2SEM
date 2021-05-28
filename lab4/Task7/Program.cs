using System;
using System.Threading;

namespace Task7
{
    class Program
    {
        private static Mutex mutexJbj = new Mutex();
        static void Main(string[] args)
        {
            char[,] matrix = GetMatrix();

            
            Thread T1 = new Thread(Search);
            T1.Name = "1-й розвідник";
            
            Thread T2 = new Thread(Search);
            T2.Name = "2-й розвідник";
            
            Thread T3 = new Thread(Search);
            T3.Name = "3-й розвідник";

            Scout scout1 = new Scout(T1.Name);
            Scout scout2 = new Scout(T2.Name);
            Scout scout3 = new Scout(T3.Name);
            
            T1.Start(scout1);
            T2.Start(scout2);
            T3.Start(scout3);
        }

        private static char[,] GetMatrix()
        {
            // '0' - пустое поле;  'P' - цель
            Console.WriteLine(new string('-',40));
            char[,] mas = new char[10,10];
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int num = rand.Next(0, 2);
                    if (num == 0)
                        mas[i, j] = '0';
                    else if(num==1)
                        mas[i, j] = 'P';
                    Console.Write(mas[i,j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 40));
            return mas;
        }

        private static void Search(object x)
        {
            Scout scout = (Scout) x;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mutexJbj.WaitOne();
                    
                    
                    
                    mutexJbj.ReleaseMutex();
                }
            }

        }
    }
}
