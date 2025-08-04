using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _02_Social_Media_Buzz_Predictions
{
    class LR
    {
        private int[] x { get; set; }
        private int[] y { get; set; }

        public LR(int[] xvalues, int[] yvalues)
        {
            x = xvalues;
            y = yvalues;
            Slope();
            Intercept();
        }

        public double Slope()
        {
            int xtotals = x.Sum();
            int ytotals = y.Sum();
            int n = x.Length;

            int xytotals = 0;
            int x2totals = 0;

           for (int i = 0; i < n; i++)
           {
                xytotals += x[i] * y[i];
                x2totals += x[i] * x[i];
           }

            double up = n * xytotals - xtotals * ytotals;
            double down = n * x2totals - xtotals * xtotals;
            return up / down;
        }

        public double Intercept()
        {
            return Math.Round((y.Sum() - Slope() * x.Sum()) / x.Length, 4);
        }

        public double Predict(int x)
        {
            return Math.Round(Slope() * x + Intercept(), 1);
        }

        public double RSquared()
        {
            int xtotals = x.Sum();
            int ytotals = y.Sum();
            int n = x.Length;

            int xytotals = 0;
            int x2totals = 0;
            int y2totals = 0;

            for (int i = 0; i < n; i++)
            {
                xytotals += x[i] * y[i];
                x2totals += x[i] * x[i];
                y2totals += y[i] * y[i];
            }

            double up = n * xytotals - xtotals * ytotals;

            int left = n * x2totals - xtotals * xtotals;

            int right = n * y2totals - ytotals * ytotals;

            double down = Math.Sqrt(left) * Math.Sqrt(right);

            return Math.Round(Math.Pow(up / down, 2), 4);
        }
    }
}
