using System.Collections;
using System.Text;

namespace Tree25;

public class BinaryTree : IEnumerable<int>
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

    public int Count { get; private set; }

    public void Add(int value)
    {
        if (Count == 0)
        {
            var node = new Node()
            {
                Value = value
            };

            Root = node;
            Last = node;
            Count++;

            return;
        }

        Last.Right = new Node()
        {
            Value = value
        };

        Last = Last.Right;
        Count++;
    }

    public class Node
    {
        public int Value { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
    }

    public IEnumerator<int> GetEnumerator()
    {
        var node = Root;
        while (node is not null)
        {
            yield return node.Value;
            node = node.Right;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
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
        
        if(node.Right != null) 
        {
            GenerateStringNode(node.Right, new StringBuilder().Append(prefix).Append(isTail ? "│  " : "   "), false, sb);
        }
        
        sb.Append(prefix).Append(isTail ? "└──" : "┌──").Append(node.Value).Append('\n');
        
        if(node.Left != null) 
        {
            GenerateStringNode(node.Left, new StringBuilder().Append(prefix).Append(isTail ? "   " : "│  "), true, sb);
        }
        
        return sb;
    }
}