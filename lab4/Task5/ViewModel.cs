using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task5.Annotations;

namespace Task5
{
    class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            _InputArray = new int[25];
            _OutputArrayMinMax = new int[25];
            _OutputArrayMaxMin = new int[25];
            
            rand = new Random();
            
            for (int i = 0; i < _InputArray.Length; i++)
                _InputArray[i] = rand.Next(-50, 50);

            Array.Copy(_InputArray, _OutputArrayMinMax,_InputArray.Length);
            Array.Copy(_InputArray, _OutputArrayMaxMin, _InputArray.Length);


            TMinMax = new Thread(SortMinMax);
            TMaxMin = new Thread(SortMaxMin);
        }

        private int[] _InputArray;

        private int[] _OutputArrayMinMax;
        private int[] _OutputArrayMaxMin;

        private Random rand;
        
        private string _SOMinMax;
        private string _SOMaxMin;

        public string StringInputArray
        {
            get
            {
                string s = "";

                foreach (var i in _InputArray)
                    s += i + " ";
                return s;
            }
        }
        public string StringOutMinMaxArray
        {
            get => _SOMinMax;
            set
            {
                _SOMinMax = value;
                OnPropertyChanged("StringOutMinMaxArray");
            }
        }
        public string StringOutMaxMinArray
        {
            get => _SOMaxMin;
            set
            {
                _SOMaxMin = value;
                OnPropertyChanged("StringOutMaxMinArray");
            }
        }


        private Thread TMinMax, TMaxMin;
        
        private void SortMinMax()
        {
            int temp;
            for (int i = 0; i < _OutputArrayMinMax.Length - 1; i++)
            {
                for (int j = i + 1; j < _OutputArrayMinMax.Length; j++)
                {
                    if (_OutputArrayMinMax[i] > _OutputArrayMinMax[j])
                    {
                        temp = _OutputArrayMinMax[i];
                        _OutputArrayMinMax[i] = _OutputArrayMinMax[j];
                        _OutputArrayMinMax[j] = temp;

                        StringOutMinMaxArray = GetStringArray(_OutputArrayMinMax);
                        Thread.Sleep(100);
                    }
                }
            }
        }
        private void SortMaxMin()
        {
            int temp;
            for (int i = 0; i < _OutputArrayMaxMin.Length - 1; i++)
            {
                for (int j = i + 1; j < _OutputArrayMaxMin.Length; j++)
                {
                    if (_OutputArrayMaxMin[i] < _OutputArrayMaxMin[j])
                    {
                        temp = _OutputArrayMaxMin[i];
                        _OutputArrayMaxMin[i] = _OutputArrayMaxMin[j];
                        _OutputArrayMaxMin[j] = temp;

                        StringOutMaxMinArray = GetStringArray(_OutputArrayMaxMin);
                        Thread.Sleep(100);
                    }
                }
            }
        }

        private string GetStringArray(int[] array)
        {
            string s = "";

            foreach (var i in array)
                s += i + " ";
            return s;
        }
        
        public void Start()
        {
            TMinMax.Start();
            TMaxMin.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
