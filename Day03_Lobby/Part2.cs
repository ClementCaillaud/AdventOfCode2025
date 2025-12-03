using Common.Interfaces;
using Common.Services;
using System.Text;

namespace Day03_Lobby;

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
        double total = 0;

        for (var lineIndex = 0; lineIndex < input.Length; lineIndex++)
        {
            var totalVoltage = new StringBuilder();
            var latestIndex = -1;

            for (var digitsLeft = 12; digitsLeft > 0; digitsLeft--)
            {
                var biggestNumber = 0;

                for (var characterIndex = latestIndex + 1; characterIndex <= input[lineIndex].Length - digitsLeft; characterIndex++)
                {
                    int characterValue = input[lineIndex][characterIndex] - '0';
                    if (characterValue > biggestNumber)
                    {
                        biggestNumber = characterValue;
                        latestIndex = characterIndex;
                    }
                }
                totalVoltage.Append(biggestNumber);
            }
            total += double.Parse(totalVoltage.ToString());
        }
        return total.ToString();
    }
}
