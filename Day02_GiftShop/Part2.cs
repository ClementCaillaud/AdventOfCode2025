using Common.Interfaces;
using Common.Services;
using System.Text;
using System.Text.RegularExpressions;

namespace Day02_GiftShop;

public class Part2 : IPart
{
    private readonly string _inputPath;

    public Part2(string inputPath)
    {
        _inputPath = inputPath;
    }

    public string Process()
    {
        var input = InputService.GetAllInOneLine(_inputPath);
        var ranges = input.Split(',', StringSplitOptions.RemoveEmptyEntries);

        long total = 0;

        for (int i = 0; i < ranges.Length; i++)
        {
            var rangeStart = long.Parse(ranges[i].Split('-')[0]);
            var rangeEnd = long.Parse(ranges[i].Split('-')[1]);

            for (long j = rangeStart; j <= rangeEnd; j++)
            {
                var currentNumber = j.ToString();
                var pattern = new StringBuilder();

                for (int k = 0; k < currentNumber.Length / 2; k++)
                {
                    pattern.Append(currentNumber[k]);
                    var regexPattern = $"({pattern})";
                    var matches = Regex.Matches(currentNumber, regexPattern);
                    if (matches.Sum(m => m.Length) == currentNumber.Length)
                    {
                        total += j;
                        break;
                    }
                }
            }
        }

        return total.ToString();
    }
}