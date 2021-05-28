using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using OxyPlot;
using OxyPlot.Series;
using Task4.Annotations;

namespace Task4
{
    class ViewModel
    {
        public ViewModel()
        {
            _func = x => 23d * Math.Pow(x, 2) - 33;
            
            T = new Thread(FillingPoints);

            _graph = new PlotModel();
            _graph.Series.Add(new LineSeries());
            _graph.Series[0].ClearSelection();
            T.Start();
        }

        private Thread T;
        
        private PlotModel _graph;
        public PlotModel Graph
        {
            get => _graph;
            set
            {
                _graph = value;
            }
        }

        
        private Func<double, double> _func;

        private void FillingPoints()
        {
            for (double x = -5; x <= 5; x+=0.1)
            {
                (_graph.Series[0] as LineSeries).Points.Add(new DataPoint(x,_func(x)));
                _graph.InvalidatePlot(true);
                Thread.Sleep(100);
            }
        }
    }
}
