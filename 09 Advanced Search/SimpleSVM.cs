using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _09_Advanced_Search
{
    public class SimpleSVM
    {
        public double[] Weights;
        public double Bias;

        public SimpleSVM(int dimension)
        {
            Weights = new double[dimension];
        }

        public int Predict(double[] doubles)
        {
            double result = DotProduct(Weights, doubles) - Bias;
            if (result >= 0) return 1;
            return -1;
        }

        public void Train(double[][] inputs, int[] labels, double learningrate, int epochs) //v2 = iterations
        {
            for (int i = 0; i < epochs; i++)
            {
                for (int j = 0; j < inputs.Length; j++)
                {
                    double prediction = Predict(inputs[j]);
                    if (prediction != labels[j])
                    {
                        // Update weights and bias
                        for (int k = 0; k < Weights.Length; k++)
                        {
                            Weights[k] += learningrate * labels[j] * inputs[j][k];
                        }
                        Bias -= learningrate * labels[j];
                    }

                }
            }
        }

        private double DotProduct(double[] a, double[] b)
        {
            return a.Zip(b, (x, y) => x * y).Sum();
        }
    }
}
