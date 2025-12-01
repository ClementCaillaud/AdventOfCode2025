namespace Common.Services;

public static class InputService
{
    public static string GetAllInOneLine(string filePath)
    {
        return File.ReadAllText(filePath);
    }

    public static string[] ReadAllLines(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        Console.WriteLine(string.Format("Found {0} lines", lines.Length));
        return lines;
    }
}
