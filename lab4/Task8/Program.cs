using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            Primes primes = new Primes(0,100);
            primes.Start();
        }
    }
}
