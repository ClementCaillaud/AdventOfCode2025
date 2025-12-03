using Common.Interfaces;
using Common.Services;

namespace Day03_Lobby;

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

        for (var i = 0; i < input.Length; i++)
        {
            var maxFirst = new Tuple<int, int>(-1, 0);
            var maxLast = new Tuple<int, int>(-1, 0);

            for (var j = 0; j < input[i].Length - 1; j++)
            {
                int characterValue = input[i][j] - '0';
                if (characterValue > maxFirst.Item2)
                {
                    maxFirst = new Tuple<int, int>(j, characterValue);
                }
            }
            for (var j = maxFirst.Item1 + 1; j < input[i].Length; j++)
            {
                int characterValue = input[i][j] - '0';
                if (characterValue > maxLast.Item2)
                {
                    maxLast = new Tuple<int, int>(j, characterValue);
                }
            }
            var maxVoltage = maxFirst.Item2 * 10 + maxLast.Item2;
            total += maxVoltage;
        }
        return total.ToString();
    }
}
