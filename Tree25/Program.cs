using Tree.Graph;

namespace Tree25;

public class Program
{
    static void Main()
    {
        Console.Write("Введите кол-во элементов: ");
        var count = int.Parse(Console.ReadLine()!);
        var random = new Random();
        var tree = new BinaryTree();

        for (int i = 0; i < count; i++)
        {
            tree.Add(random.Next(100));
        }
        
        tree.Root.Print();
    }
}