using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Task3
{
    class Program
    {
        private static Mutex mutexObj = new Mutex();
        static void Main(string[] args)
        {
            Console.Write("Введіть до якого числа шукати: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n<0)
                return;

            Thread fib = new Thread(Fib);
            Thread prime = new Thread(Prime);
            fib.Start(n);
            prime.Start(n);

            List<string> fibs = new List<string>();
            List<string> primes = new List<string>();
            
            mutexObj.WaitOne();
            using (StreamReader read = new StreamReader("Fib.txt"))
            {
                string s = read.ReadToEnd();
                fibs = s.Split("\r\n").ToList();
                fibs.RemoveAt(fibs.Count-1);
                Console.Write($"Числа фиббоначі від 0 до {n}:");
                Show(fibs);
                read.Dispose();
            }
            Console.WriteLine("\n"+new string('-',60));
            using (StreamReader read = new StreamReader("Prime.txt"))
            {
                string s = read.ReadToEnd();
                primes = s.Split("\r\n").ToList();
                primes.RemoveAt(primes.Count - 1);
                Console.Write($"Прості числа від 0 до {n}:");
                Show(primes);
                read.Dispose();
            }

            int count = 0;
            foreach (var i in fibs)
            {
                foreach (var j in primes)
                {
                    if (i == j)
                        count++;
                }
            }
            Console.WriteLine("\n" + new string('-', 60));

            Console.WriteLine($"Кількість знайдених простих чисел фиббоначи: {count}");
            mutexObj.ReleaseMutex();
            
        }

        public static void Fib(object n)
        {
            mutexObj.WaitOne();
            using (StreamWriter write = new StreamWriter("Fib.txt"))
            {
                if (File.Exists("Fib.txt"))
                {
                    int num = (int) n;
                    int fib1 = 1;
                    int fib2 = 1;
                    int result = 1;
                    int i = 1;
                    while (result <= num)
                    {
                        if (i == 1)
                            result = fib1;
                        else if (i==2)
                            result = fib2;
                        else if(i>2)
                        {
                            result = fib2 + fib1;
                            fib1 = fib2;
                            fib2 = result;
                        }

                        if (result > num)
                            break;
                        write.WriteLine(result);
                        i++;
                    }
                    write.Dispose();
                }
            }
            mutexObj.ReleaseMutex();
        }
        public static void Prime(object n)
        {
            using (StreamWriter write = new StreamWriter("Prime.txt"))
            {
                if (File.Exists("Prime.txt"))
                {
                    int num = (int) n;
                    for (int i = 0; i < num; i++)
                    {
                        if(IsPrime(i))
                            write.WriteLine(i);
                    }
                }
            }
        }

        public static bool IsPrime(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        public static void Show<T>(List<T> list)
        {
            foreach (var i in list)
            {
                Console.Write(i+", ");
            }
        }
    }
}
