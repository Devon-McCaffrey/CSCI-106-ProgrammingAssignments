using System;
using System.Collections.Generic;
using System.IO;

public class SvgGenerator
{
    private List<string> svgElements = new List<string>();
    private Random rand = new Random();

    public void AddRectangle(int x, int y, int width, int height, string fillColor)
    {
        string rect = $"<rect x=\"{x}\" y=\"{y}\" width=\"{width}\" height=\"{height}\" fill=\"{fillColor}\" />";
        svgElements.Add(rect);
    }

    public void GenerateSvgFromFile(string inputFilePath)
    {
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        var lines = File.ReadAllLines(inputFilePath);

        foreach (var line in lines)
        {
            try
            {
                var parts = line.Split(')');
                var coordPart = parts[0].Trim('(', ' ');
                var colorPart = parts[1].Trim();

                var coords = coordPart.Split(',');
                int x = int.Parse(coords[0]);
                int y = int.Parse(coords[1]);
                string color = colorPart;

                int size = rand.Next(5, 21); // Random size between 5 and 20
                AddRectangle(x * size, y * size, size, size, color);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing line: {line} | {ex.Message}");
            }
        }

        SaveSvg("output.svg");
        Console.WriteLine("SVG generated as output.svg");
    }

    public void SaveSvg(string fileName)
    {
        var svgContent = $"<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">\n{string.Join("\n", svgElements)}\n</svg>";
        File.WriteAllText(fileName, svgContent);
    }

    public List<string> GetSvgElements() => svgElements;
}

class Program
{
    static void Main()
    {
        SvgGenerator generator = new SvgGenerator();
        generator.GenerateSvgFromFile("input.txt");
    }
}
