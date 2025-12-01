using Common.Interfaces;
using System.Diagnostics;

namespace Common.Application;

public static class Application
{
    /// <summary>
    /// Lauch process
    /// </summary>
    /// <param name="part"></param>
    public static void ProcessPart(IPart part, bool isExampleData = false)
    {
        Console.WriteLine("=========================================");

        var partName = part.GetType().Name;
        Console.WriteLine(isExampleData ?
            $"Start {partName} - Example Data" :
            $"Start {partName}"
        );

        var watch = Stopwatch.StartNew();
        var result = part.Process();
        watch.Stop();

        Console.WriteLine($"End {partName} in {watch.ElapsedMilliseconds} ms");

        if (string.IsNullOrEmpty(result))
            Console.WriteLine($"{partName} : No result");
        else
            Console.WriteLine($"{partName} : {result}");

        Console.WriteLine("=========================================");
    }
}
