using System.Collections;

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

    public static void AddLeaf(Node? rootNode)
    {
        var node = rootNode;
        while (node != null)
        {
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
                
                break;
            }

            node = node.Right ?? node.Left;
        }
    }

    public void ForEach(Action<Node> action)
    {
        var node = Root;
        while (node != null)
        {
            action(node);
            
            node = node.Right ?? node.Left;
        }
    }

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
        return "[" + string.Join(" ", this) + "]";
    }

    private static bool IsLeaf(Node node)
    {
        return node.Left is null && node.Right is null;
    }

    private static bool IsEvenValue(Node node)
    {
        return node.Value % 2 == 0;
    }
}