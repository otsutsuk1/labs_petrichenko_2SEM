using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Task2.Annotations;

namespace Task2
{
    class ViewModel:INotifyPropertyChanged
    {
        public ViewModel()
        {
            T = new Thread(Calculate);
        }
        private double _value;
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }
        
        public double X { get; set; }

        private bool IsRunning = true;

        private Thread T;

        public void Calculate()
        {
            Value = 1;
            double pow = 1;

            double sinodd = 1;
            double cosodd = 2;
            while (true)
            {

                Value += Formula(pow,sinodd,cosodd);
                sinodd = cosodd*2d;
                cosodd = sinodd * 2d;
                pow *= 2d;
                Thread.Sleep(1000);
                if (!IsRunning)
                    break;
            }
        }

        private double Formula(double pow, double sinodd,double cosodd) => sinodd*Math.Pow(Math.Sin(X),pow) - cosodd*Math.Pow(Math.Cos(X),pow);


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Start()
        {
            IsRunning = true;
            T.Start();
        }
        public void Stop()
        {
            IsRunning = false;
        }
    }
}
