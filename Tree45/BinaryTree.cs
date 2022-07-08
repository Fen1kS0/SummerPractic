using System.Text;
using Tree.Core;

namespace Tree45;

public class BinaryTree
{
    public BinaryTree()
    {
    }

    public BinaryTree(IEnumerable<int> enumerable)
    {
        foreach (var value in enumerable)
        {
            Add(value);
        }
    }

    public Node? Root { get; private set; }

    public static void AddLeaf(Node? node)
    {
        if (node == null)
        {
            return;
        }

        if (IsLeaf(node))
        {
            var newNode = new Node()
            {
                Value = node.Value
            };

            if (IsEvenValue(node))
            {
                node.Right = newNode;
            }
            else
            {
                node.Left = newNode;
            }

            return;
        }

        AddLeaf(node.Left);
        AddLeaf(node.Right);
    }

    public void Add(int value)
    {
        var newNode = new Node()
        {
            Value = value
        };

        if (Root == null)
        {
            Root = newNode;

            return;
        }

        Add(Root, newNode);
    }

    public void Add(Node parent, Node newNode)
    {
        if (newNode.Value < parent.Value)
        {
            if (parent.Left == null)
            {
                parent.Left = newNode;
            }
            else
            {
                Add(parent.Left, newNode);
            }
        }
        else
        {
            if (parent.Right == null)
            {
                parent.Right = newNode;
            }
            else
            {
                Add(parent.Right, newNode);
            }
        }
    }

    public override string ToString()
    {
        return GenerateStringNode(Root, new StringBuilder(), true, new StringBuilder()).ToString();
    }

    private StringBuilder GenerateStringNode(Node? node, StringBuilder prefix, bool isTail, StringBuilder sb)
    {
        if (node == null)
        {
            return sb;
        }

        if (node.Right != null)
        {
            GenerateStringNode(
                node.Right,
                new StringBuilder().Append(prefix).Append(isTail ? "│  " : "   "),
                false,
                sb
            );
        }

        sb.Append(prefix).Append(isTail ? "└──" : "┌──").Append(node.Value).Append('\n');

        if (node.Left != null)
        {
            GenerateStringNode(
                node.Left,
                new StringBuilder().Append(prefix).Append(isTail ? "   " : "│  "),
                true,
                sb
            );
        }

        return sb;
    }

    private static bool IsLeaf(Node node)
    {
        return node.Left == null && node.Right == null;
    }

    private static bool IsEvenValue(Node node)
    {
        return node.Value % 2 == 0;
    }
}