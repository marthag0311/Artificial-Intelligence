namespace _08_Facebook_Ad_Targeting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NB nb = new NB("data_simple.txt");
            Console.WriteLine(nb.Predict("This is"));
            Console.WriteLine(nb.IsSpam("This is"));#
        }
    }
}