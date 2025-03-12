using System;
using System.IO;
using System.Text.RegularExpressions;

public class SvgGenerator
{
    private const int SquareSize = 20;

    public void GenerateFromFile(string inputFile, string outputFile)
    {
        string svg = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"500\" height=\"500\">\n";
        

        foreach (var line in File.ReadAllLines(inputFile))
        {
            var match = Regex.Match(line, pattern);
            if (match.Success)
            {
                int x = int.Parse(match.Groups[1].Value) * SquareSize;
                int y = int.Parse(match.Groups[2].Value) * SquareSize;
                string color = match.Groups[3].Value;

                svg += $"<rect x=\"{x}\" y=\"{y}\" width=\"{SquareSize}\" height=\"{SquareSize}\" style=\"fill:{color}\" />\n";
            }
        }

        svg += "</svg>";
        File.WriteAllText(outputFile, svg);
    }
}

class Program
{
    static void Main()
    {
        var generator = new SvgGenerator();
        generator.GenerateFromFile("input.txt", "output.svg");
        Console.WriteLine("SVG generated successfully.");
    }
}
