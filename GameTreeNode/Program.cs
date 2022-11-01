namespace GameTreeNode
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var root = new GameTreeNodeImplementation(5, true);

            Console.WriteLine(root.CountWins(true)); // geeft 2 voor speler A
            Console.WriteLine(root.CountWins(false)); // geeft 7 voor speler B
        }

    }

}

