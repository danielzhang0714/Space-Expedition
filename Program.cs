namespace Space_Expedition
{
    internal class Program {
        static void Main(string[] args) {
            Readfile rf = new Readfile();
            Artifact[] artifacts;
            int count;
            rf.Read("galactic_vault.txt", out artifacts, out count);
            string[] decoded = rf.AddToArr(artifacts, count);
            rf.PrintArtiName(decoded);

        }
    }
}
