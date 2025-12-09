using Common.Interfaces;
using Common.Services;

namespace Day07_Laboratories;

public class Part2 : IPart
{
    private readonly string _inputPath;

    public Part2(string inputPath)
    {
        _inputPath = inputPath;
    }

    public string Process()
    {
        var input = InputService.ReadAllLines(_inputPath);

        List<int> pipeIndexes = [input[0].IndexOf('S')];
        Dictionary<int, long> beams = new() { { input[0].IndexOf('S'), 1 } };

        for (int lineIndex = 1; lineIndex < input.Length; lineIndex++)
        {
            List<int> pipesToSplit = [];
            List<int> newPipes = [];
            Dictionary<int, long> newBeams = [];

            for (int pipeIndex = 0; pipeIndex < pipeIndexes.Count; pipeIndex++)
            {
                var colIndex = pipeIndexes[pipeIndex];

                if (input[lineIndex][colIndex] == '^')
                {
                    pipesToSplit.Add(colIndex);
                    newPipes.AddRange(colIndex - 1, colIndex + 1);

                    newBeams.TryAdd(colIndex - 1, 0);
                    newBeams[colIndex - 1] += beams[colIndex];
                    newBeams.TryAdd(colIndex + 1, 0);
                    newBeams[colIndex + 1] += beams[colIndex];
                }
                else
                {
                    newBeams.TryAdd(colIndex, 0);
                    newBeams[colIndex] += beams[colIndex];
                }
            }
            pipeIndexes.RemoveAll(i => pipesToSplit.Contains(i));
            pipeIndexes.AddRange(newPipes);
            pipeIndexes = [.. pipeIndexes.Distinct()];
            beams = newBeams;
        }
        long total = beams.Values.Sum();
        return total.ToString();
    }
}