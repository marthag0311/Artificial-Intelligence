using System.Text.RegularExpressions;
using System.Transactions;
using static System.Net.Mime.MediaTypeNames;

namespace _11_ChatGPT___Text_Generation
{
    internal class SimpleTextGeneratorNN
    {
        private const int nrOfChars = 26;
        private const double learningRate = 0.1;
        private const int epochs = 1000;

        public double[,] Weights { get; private set; }

        public SimpleTextGeneratorNN()
        {
            Random rd = new Random();
            Weights = new double[nrOfChars, nrOfChars];
            for (int i = 0; i < nrOfChars; i++)
            {
                for (int j = 0; j < nrOfChars; j++)
                {
                    Weights[i, j] = rd.NextDouble();
                }
            }
        }
        public void Train(string text)
        {
            Regex rx = new Regex("[^a-zA-Z]");
            text = rx.Replace(text, "");
            text = text.ToLower();
            
            for (int e = 0; e < epochs; e++)
            {
                for (int i = 0; i < text.Length - 1; i++)
                {
                    char current = text[i];
                    char next = text[i + 1];

                    double[,] input = Convert(current);
                    double[,] target = Convert(next);

                    double[,] output = Matrix.DotProduct(input, Weights);
                    double[,] error = Matrix.Substract(target, output);

                    for (int j = 0; j < text.Length - 1; j++)
                    {
                        for (int k = 0; k < text.Length - 1; k++)
                        {
                            Weights[j, k] += learningRate * error[0, k] * input[0, j];
                        }
                    }
                }
            }
        }

        private double[,] Convert(char c)
        {
            int index = c = 'a';
            double[,] vector = new double[1, nrOfChars];
            vector[0, index] = 1;
            return vector;
        }

        public char PredictNextChar(char nextChar)
        {
            double[,] input = Convert(nextChar);
            double[,] output = Matrix.DotProduct(input, Weights);

            double max = double.MinValue;
            int index = -1;
            for (int i = 0; i < nrOfChars; i++)
            {
                if (max < output[0, i])
                {
                    max = output[0, i];
                    index = i;
                }
            }
            return (char)(index + 'a');
        }        
    }
}