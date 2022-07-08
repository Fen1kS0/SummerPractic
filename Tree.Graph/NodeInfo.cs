using Tree.Core;

namespace Tree.Graph;

public class NodeInfo
{
    public Node Node;
    public string Text;
    public int StartPos;
    public int Size => Text.Length;

    public int EndPos
    {
        get => StartPos + Size;
        set => StartPos = value - Size;
    }

    public NodeInfo Parent, Left, Right;
}