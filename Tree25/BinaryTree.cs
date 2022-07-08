using System.Text;
using Tree.Core;

namespace Tree25;

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
    public Node? Last { get; private set; }

    public void Add(int value)
    {
        if (Root == null)
        {
            var node = new Node()
            {
                Value = value
            };

            Root = node;
            Last = node;

            return;
        }

        Last.Right = new Node()
        {
            Value = value
        };

        Last = Last.Right;
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
            GenerateStringNode(node.Right, new StringBuilder().Append(prefix).Append(isTail ? "│  " : "   "), false,
                sb);
        }

        sb.Append(prefix).Append(isTail ? "└──" : "┌──").Append(node.Value).Append('\n');

        if (node.Left != null)
        {
            GenerateStringNode(node.Left, new StringBuilder().Append(prefix).Append(isTail ? "   " : "│  "), true, sb);
        }

        return sb;
    }
}