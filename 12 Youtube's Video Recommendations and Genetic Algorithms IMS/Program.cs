namespace _12_Youtube_s_Video_Recommendations_and_Genetic_Algorithms_IMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GeneticAlgorithm ga = new GeneticAlgorithm(200, 8, 6);
            ga.Run();
        }
    }
}