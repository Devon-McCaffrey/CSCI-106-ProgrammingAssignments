namespace SemesterProject;

public static class Program
{
    public static void Main()
    {
        var svg = new SvgBuilder(500, 500)

        .AddRectangle(200, 100, 70, 300, "00FF00")
        .AddRectangle(100, 150, 100, 200, "00FF00")
        .AddRectangle(150, 200, 120, 100, "00FF00")
        .Build();

        Console.Write("Absolute path to save SVG at: ");
        var path = Console.ReadLine() ?? "";
        using var streamWriter = new StreamWriter(path);

        streamWriter.WriteLine(svg);
    }
}
