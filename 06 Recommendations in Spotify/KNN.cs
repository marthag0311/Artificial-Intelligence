using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Recommendations_in_Spotify
{
    internal class KNN
    {
        private Dictionary<double[], string> Data { get; set; }

        public KNN(string file)
        {
            Data = new Dictionary<double[], string>();
            ReadData(file);
        }

        private ReadData(string file)
        {
            foreach (var item in file.ReadAllLines("iris.dat"))
            {
                List<string> strings = item.Split(',').ToList();
                string value = strings[strings.Count - 1];
                strings.RemoveAt(strings.Count - 1);

                double[] features = Array.ConvertAll(strings.ToArray(), Convert.ToDouble);
                Data[features] = value;
            }
        }

        private double CalculateDistance(double[] p, double[] q)
        {
            if (p.Length != q.Length) throw new Exception("Different Lengths!");

            double distance = 0.0;

            for (int i = 0; i < p.Length; i++)
            {
                distance += Math.Pow(p[i] - q[i], 2);
            }
            return Math.Sqrt(distance);
        }

        public string Classify(double[] array)
        {
            double minDistance = int.MaxValue;
            string closestClass = null;

            foreach (var item in Data)
            {
                doublle distance = CalculateDistance(array, item.Key);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestClass = item.Value;
                }
            }
            return closestClass;
        }
    }
}
