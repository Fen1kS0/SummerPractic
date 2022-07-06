namespace Tree45;

public class Program
{
    static void Main()
    {
        var list = new List<int>()
        {
            5, 7, 3, 2, 6
        };
        
        var tree = new BinaryTree(list);
        Console.WriteLine(tree);
        BinaryTree.AddLeaf(tree.Root);
        Console.WriteLine("==========================");
        Console.WriteLine(tree);
    }
}