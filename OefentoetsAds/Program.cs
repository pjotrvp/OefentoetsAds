using OefentoetsAds;



class Program
{
    public static void Main(string[] args)
    {
        GameTreeNode root = new GameTreeNode(5, true);

        Console.WriteLine(root.countWins(true)); // geeft 2 voor speler A
        Console.WriteLine(root.countWins(false)); // geeft 7 voor speler B

        // Test je code ook met andere aantallen!
    }

}

