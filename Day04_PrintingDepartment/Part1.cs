using Common.Interfaces;
using Common.Services;

namespace Day04_PrintingDepartment;

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

        for (var lineIndex = 0; lineIndex < input.Length; lineIndex++)
        {
            for (var charIndex = 0; charIndex < input[lineIndex].Length; charIndex++)
            {
                if (input[lineIndex][charIndex] != '@')
                    continue;

                var adjacentRolls = GetNumberOfAdjacentRolls(input, lineIndex, charIndex);
                if (adjacentRolls < 4)
                    total++;
            }
        }
        return total.ToString();
    }

    private static int GetNumberOfAdjacentRolls(string[] input, int lineIndex, int charIndex)
    {
        var total = 0;
        for (var i = -1; i <= 1; i++)
        {
            for (var j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                    continue;
                var checkLineIndex = lineIndex + i;
                var checkCharIndex = charIndex + j;
                if (checkLineIndex < 0 || checkLineIndex >= input.Length ||
                    checkCharIndex < 0 || checkCharIndex >= input[checkLineIndex].Length)
                    continue;
                if (input[checkLineIndex][checkCharIndex] == '@')
                    total++;
            }
        }
        return total;
    }
}
