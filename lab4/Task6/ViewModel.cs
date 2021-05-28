using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task6.Annotations;

namespace Task6
{
    class ViewModel
    {
        public ViewModel()
        {
            Count = 1;
            rand = new Random();

            #region Thread init
            FirstR = new Thread(Run1);
            FirstR.Name = "0";
            
            SecondR = new Thread(Run2);
            SecondR.Name = "1";
            
            ThirdR = new Thread(Run3);
            ThirdR.Name = "2";
            
            FourthR = new Thread(Run4);
            FourthR.Name = "3";
            
            FifthR = new Thread(Run5);
            FifthR.Name = "4";
            
            SixthR = new Thread(Run6);
            SixthR.Name = "5";
            
            SeventhR = new Thread(Run7);
            SeventhR.Name = "6";
            
            CountR = new Thread(CountRunner);


            #endregion

            #region Runners init

            FirstRunner = new Runner();
            SecondRunner = new Runner();
            ThirdRunner = new Runner();
            FourthRunner = new Runner();
            FifthRunner = new Runner();
            SixthRunner = new Runner();
            SeventhRunner = new Runner();

            #endregion

            allThreads = new List<Thread>() {FirstR, SecondR, ThirdR, FourthR, FifthR, SixthR, SeventhR};
            allRunners = new List<Runner>() { FirstRunner,SecondRunner,ThirdRunner,FourthRunner,FifthRunner,SixthRunner,SeventhRunner};
        }

        private Random rand;
        private int Count;
        #region Main fields and propertys
        
        public Runner FirstRunner { get; set; }
        public Runner SecondRunner { get; set; }
        public Runner ThirdRunner { get; set; }
        public Runner FourthRunner { get; set; }
        public Runner FifthRunner { get; set; }
        public Runner SixthRunner { get; set; }
        public Runner SeventhRunner { get; set; }

        private List<Runner> allRunners;

        #endregion
        
        #region Threads

        private Thread FirstR;
        private Thread SecondR;
        private Thread ThirdR;
        private Thread FourthR;
        private Thread FifthR;
        private Thread SixthR;
        private Thread SeventhR;
        private Thread CountR;
        
        private List<Thread> allThreads;
        
        #endregion
        
        #region Run methods

        private void Run1()
        {
            var pause = GetPausesList();
            while (FirstRunner.Value < 100)
            {
                FirstRunner.Value += 5;
                foreach (var i in pause)
                {
                    if (FirstRunner.Value > i-5 && FirstRunner.Value < i+5)
                    {
                        Thread.Sleep(500);
                    }
                }
                Thread.Sleep(500);
            }
        }
        private void Run2()
        {
            var pause = GetPausesList();
            while (SecondRunner.Value < 100)
            {
                SecondRunner.Value += 5;
                foreach (var i in pause)
                {
                    if (SecondRunner.Value > i - 5 && SecondRunner.Value < i + 5)
                    {
                        Thread.Sleep(500);
                    }
                }
                Thread.Sleep(500);
            }
        }
        private void Run3()
        {
            var pause = GetPausesList();
            while (ThirdRunner.Value < 100)
            {
                ThirdRunner.Value += 5;
                foreach (var i in pause)
                {
                    if (ThirdRunner.Value > i - 5 && ThirdRunner.Value < i + 5)
                    {
                        Thread.Sleep(500);
                    }
                }
                Thread.Sleep(500);
            }
        }
        private void Run4()
        {
            var pause = GetPausesList();
            while (FourthRunner.Value < 100)
            {
                FourthRunner.Value += 5;
                foreach (var i in pause)
                {
                    if (FourthRunner.Value > i - 5 && FourthRunner.Value < i + 5)
                    {
                        Thread.Sleep(500);
                    }
                }
                Thread.Sleep(500);
            }
        }
        private void Run5()
        {
            var pause = GetPausesList();
            while (FifthRunner.Value < 100)
            {
                FifthRunner.Value += 5;
                foreach (var i in pause)
                {
                    if (FifthRunner.Value > i - 5 && FifthRunner.Value < i + 5)
                    {
                        Thread.Sleep(500);
                    }
                }
                Thread.Sleep(500);
            }
        }
        private void Run6()
        {
            var pause = GetPausesList();
            while (SixthRunner.Value < 100)
            {
                SixthRunner.Value += 5;
                foreach (var i in pause)
                {
                    if (SixthRunner.Value > i - 5 && SixthRunner.Value < i + 5)
                    {
                        Thread.Sleep(500);
                    }
                }
                Thread.Sleep(500);
            }
        }
        private void Run7()
        {
            var pause = GetPausesList();
            while (SeventhRunner.Value < 100)
            {
                SeventhRunner.Value += 5;
                foreach (var i in pause)
                {
                    if (SeventhRunner.Value > i - 5 && SeventhRunner.Value < i + 5)
                    {
                        Thread.Sleep(500);
                    }
                }
                Thread.Sleep(500);
            }
        }

        #endregion

        public void Start()
        {
            FirstR.Start();
            SecondR.Start();
            ThirdR.Start();
            FourthR.Start();
            FifthR.Start();
            SixthR.Start();
            SeventhR.Start();
            CountR.Start();
        }

        private void CountRunner()
        {
            while (allThreads.Count>0)
            {
                for (int i = 0; i < allThreads.Count; i++)
                {
                    if (!allThreads[i].IsAlive)
                    {
                        allRunners[Convert.ToInt32(allThreads[i].Name)].Position = $"фінішував: {Count}-м";
                        allThreads.RemoveAt(i);
                        Count++;
                    }
                }
            }
        }
        private List<int> GetPausesList()
        {
            int NumOfPauses = rand.Next(0, 10);
            List<int> nums = new List<int>();
            for (int i = 0; i < NumOfPauses; i++)
                nums.Add(rand.Next(0,100));
            return nums;
        }
    }
}
