namespace _09_Advanced_Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SVM svm = new SVM();
            var svm = new SimpleSVM(3);
            double[][] inputs = { new double[] { 1, 2, 3 }, new double[] { 2, 3, 4 }, new double[] { 3, 3, 5 } };
            int[] labels = { 1, -1, -1 };

            svm.Train(inputs, labels, 0.01, 1000);

            var prediction = svm.Predict(new double[] { 1.5, 2.5, 3.5 });
            Console.WriteLine($"Prediction: {prediction}");

            prediction = svm.Predict(new double[] { 3, 3, 3.5 });
            Console.WriteLine($"Prediction: {prediction}");

            prediction = svm.Predict(new double[] { 2.5, 2, 2.9 });
            Console.WriteLine($"Prediction: {prediction}");
        }
    }
}