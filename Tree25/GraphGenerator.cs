using System.Diagnostics;
using QuikGraph;

namespace Tree25;

public class GraphGenerator
{
    private const string FileName = "tree";
    private const string TextFormat = ".txt";
    private const string ImageFormat = ".jpg";

    private readonly string _textPath;
    private readonly string _imagePath;

    public GraphGenerator(string directoryPath)
    {
        _textPath = Path.Combine(directoryPath, FileName + TextFormat);
        _imagePath = Path.Combine(directoryPath, FileName + ImageFormat);
    }

    public void OpenGraph(BinaryTree binaryTree)
    {
        var graph = GenerateDot(binaryTree);
        
        SaveGraph(graph, _textPath);
        ConvertToImage(_textPath, _imagePath);
        OpenImage(_imagePath);
    }

    private string GenerateDot(BinaryTree binaryTree)
    {
        var grahp = "graph {\n";

        var vertices = new List<int>();
        var edges = new List<Edge<int>>();

        binaryTree.ForEach(node =>
        {
            vertices.Add(node.Value);

            if (node.Right != null)
            {
                edges.Add(new Edge<int>(node.Value, node.Right.Value));
            }
        });
        
        foreach (var vertex in vertices)
        {
            grahp = grahp + $"{vertex}\n";
        }
        
        foreach (var edge in edges)
        {
            grahp = grahp + $"{edge.Source} -- {edge.Target}\n";
        }
        
        return grahp + "}";
    }
    
    private void SaveGraph(string graph, string path)
    {
        using (StreamWriter streamWriter = new StreamWriter(path, false))
        {
            streamWriter.Write(graph);
        }
    }
    
    private void ConvertToImage(string textPath, string imagePath)
    {
        try
        {
            //Run command to run a dot command
            var toGraphvizCommand = $"dot -T jpg {textPath} -o {imagePath}";

            //Concat the cmd run command and dot command
            var processStartInfo = new ProcessStartInfo("cmd", "/C " + toGraphvizCommand)
            {
                UseShellExecute = true 
            };
            var process = new Process();
            process.StartInfo = processStartInfo;
            
            process.Start();
            process.WaitForExit();

        }
        catch (Exception x)
        {
            Console.WriteLine(x);
        }
    }
    
    private void OpenImage(string path)
    {
        var process = new Process();
        process.StartInfo = new ProcessStartInfo(path)
        { 
            UseShellExecute = true 
        };
        process.Start();
    }
}