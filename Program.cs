namespace Space_Expedition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Readfile r = new Readfile();
            Console.WriteLine(r.decodeName("A1"));
            Console.WriteLine(r.decodeName("b2"));
            Console.WriteLine(r.decodeName("A1|B2|C3"));
            Console.WriteLine(r.decodeName("D1|E1|F1"));
            Console.WriteLine(r.decodeName("A12|B3"));
        }
    }
}
