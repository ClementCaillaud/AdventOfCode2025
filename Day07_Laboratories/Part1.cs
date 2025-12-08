using Common.Interfaces;
using Common.Services;

namespace Day07_Laboratories;

public class Part1 : IPart
{
    private readonly string _inputPath;

    public Part1(string inputPath)
    {
        _inputPath = inputPath;
    }

    public string Process()
    {
        var input = InputService.ReadAllLines(_inputPath);
        var total = 0;

        List<int> pipeIndexes = [input[0].IndexOf('S')];

        for (int lineIndex = 1; lineIndex < input.Length; lineIndex++)
        {
            List<int> pipesToSplit = [];
            List<int> newPipes = [];

            for (int pipeIndex = 0; pipeIndex < pipeIndexes.Count; pipeIndex++)
            {
                var colIndex = pipeIndexes[pipeIndex];
                if (input[lineIndex][colIndex] == '^')
                {
                    pipesToSplit.Add(colIndex);
                    newPipes.AddRange(colIndex - 1, colIndex + 1);
                    total++;
                }
            }
            pipeIndexes.RemoveAll(i => pipesToSplit.Contains(i));
            pipeIndexes.AddRange(newPipes);
            pipeIndexes = [.. pipeIndexes.Distinct()];
        }
        return total.ToString();
    }
}
