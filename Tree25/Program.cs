namespace Tree25;

public class Program
{
    static void Main()
    {
        var list = new List<int>()
        {
            1, 5, 3, 2, 6
        };

        var directoryPath = @"C:\Users\Fen1kS0\Desktop\SummerPractic\Outputs";
        
        var binaryTree = new BinaryTree(list);
        var graphGenerator = new GraphGenerator(directoryPath);
        graphGenerator.OpenGraph(binaryTree);
        BinaryTree.AddLeaf(binaryTree.Root);
        Thread.Sleep(10000);
        graphGenerator.OpenGraph(binaryTree);
    }
}