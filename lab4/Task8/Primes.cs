using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task8
{
    class Primes
    {
        public Primes(int X0, int X)
        {
            this.X0 = X0;
            this.X = X;
            sem = new Semaphore(1, 1);

        }

        private Primes prime1;
        private Primes prime2;

        private Thread T1;
        private Thread T2;
        
        private Semaphore sem;
        
        public int X0 { get; set; }
        public int X { get; set; }

        public void GetPrimes(object x)
        {
            sem.WaitOne();
            Primes pr = (Primes) x;
            Console.Write(Thread.CurrentThread.Name+": ");
            for (int i = pr.X0; i <= pr.X; i++)
            {
                if (IsPrime(i))
                {
                    Console.Write(i + " ");
                    Thread.Sleep(100);
                }
            }
            Console.WriteLine();
            sem.Release();
        }
        
        private bool IsPrime(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        public void Start()
        {
            prime1 = new Primes(X0, X / 2);
            prime2 = new Primes(X / 2, X);

            T1 = new Thread(GetPrimes);
            T2 = new Thread(GetPrimes);
            T1.Name = $"[{prime1.X0};{prime1.X}]";
            T2.Name = $"[{prime2.X0};{prime2.X}]";
            
            T1.Start(prime1);
            T2.Start(prime2);
        }
    }
}
