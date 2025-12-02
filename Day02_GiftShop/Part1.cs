using Common.Interfaces;
using Common.Services;

namespace Day02_GiftShop;

public class Part1 : IPart
{
    private readonly string _inputPath;

    public Part1(string inputPath)
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

                if (currentNumber.Length % 2 != 0)
                    continue;

                var currentNumberFirstHalf = currentNumber[..(currentNumber.Length / 2)];
                var currentNumberSecondHalf = currentNumber.Substring(currentNumber.Length / 2, currentNumber.Length / 2);

                if (currentNumberFirstHalf == currentNumberSecondHalf)
                {
                    total += j;
                }
            }
        }

        return total.ToString();
    }
}
