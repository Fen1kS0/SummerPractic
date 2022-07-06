namespace Tree25;

public class Program
{
    static void Main()
    {
        var list = new List<int>()
        {
            1, 5, 3, 2, 6
        };
        
        var tree = new BinaryTree(list);
        Console.WriteLine(tree);
    }
}