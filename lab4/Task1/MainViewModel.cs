using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using OxyPlot;
using OxyPlot.Series;

namespace Task1
{
    class MainViewModel
    {
        public PlotModel Graph1 { get; private set; }
        public PlotModel Graph2 { get; private set; }
        public PlotModel Graph3 { get; private set; }

        private Func<double, double> _func1;
        private Func<double, double> _func2;
        private Func<double, double> _func3;

        private LineSeries _f1;
        private LineSeries _f2;
        
        private LineSeries _f3First;
        private LineSeries _f3Second;

        private Thread t;

        public MainViewModel()
        {
            _func1 = x => Math.Sin(x);
            _func2 = x => 4 * x * x - 2 * x - 22;
            _func3 = x => Math.Log(x * x, Math.E) / (x * x * x);


            _f1 = new FunctionSeries(_func1, -3.5, 3.5, 0.1, "y=sin(x)");
            _f1.Color = OxyColor.Parse("#bf0a0a");
            
            _f2 = new FunctionSeries(_func2, -10, 10, 0.1, "y=4(x^2)-2x-22");
            _f2.Color = OxyColor.Parse("#08d120");


            _f3First = new FunctionSeries(_func3, -10, -0.5, 0.1, "y=ln(x^2)/(x^3)");
            _f3First.Color = OxyColor.Parse("#2804c9");
            _f3Second = new FunctionSeries(_func3, 0.5, 10, 0.1);
            _f3Second.Color = OxyColor.Parse("#2804c9");

            Graph1 = new PlotModel();
            Graph2 = new PlotModel();
            Graph3 = new PlotModel();
            
            Parallel.Invoke
            (
                () => Graph1.Series.Add(_f1),
                () => Graph2.Series.Add(_f2),
                () =>
                {
                    Graph3.Series.Add(_f3First);
                    Graph3.Series.Add(_f3Second);
                }
            );

        }
    }
}
