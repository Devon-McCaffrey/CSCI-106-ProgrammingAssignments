namespace SemesterProject;

public static class Program
{
    public static void Main()
    {
        var svg = new SvgBuilder(500, 500)

        .AddRectangle(220, 100, 70, 300, "#00FF00")
        .AddRectangle(100, 150, 50, 200, "#00FF00")
        .AddRectangle(310, 250, 100, 100, "#00FF00")
        .Build();
        
        Console.Write("Absolute path to save SVG at: SVGTest");
        var path = Console.ReadLine() ?? "";
        using var streamWriter = new StreamWriter(path);

        streamWriter.WriteLine(svg);
    }
}
