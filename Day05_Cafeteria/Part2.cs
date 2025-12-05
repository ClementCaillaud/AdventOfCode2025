using Common.Interfaces;
using Common.Services;

namespace Day05_Cafeteria;

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
        var ranges = GetInput(input, 0);
        var mergedRanges = GetMergedRanges(ranges);

        long total = 0;

        for (int i = 0; i < mergedRanges.Count; i++)
        {
            var subTotal = mergedRanges[i].Item2 - mergedRanges[i].Item1 + 1;
            total += subTotal;
        }
        return total.ToString();
    }

    private static List<Tuple<long, long>> GetInput(string[] fullInput, int startIndex)
    {
        List<Tuple<long, long>> items = [];
        for (int i = startIndex; i < fullInput.Length; i++)
        {
            if (fullInput[i] == string.Empty)
                break;

            items.Add(new Tuple<long, long>(
                long.Parse(fullInput[i].Split('-')[0]),
                long.Parse(fullInput[i].Split('-')[1])
            ));
        }
        return items;
    }

    private static List<Tuple<long, long>> GetMergedRanges(List<Tuple<long, long>> ranges)
    {
        ranges.Sort((a, b) => a.Item1.CompareTo(b.Item1));

        var merged = new List<Tuple<long, long>>();
        long currentStart = ranges[0].Item1;
        long currentEnd = ranges[0].Item2;

        for (int i = 1; i < ranges.Count; i++)
        {
            var nextStart = ranges[i].Item1;
            var nextEnd = ranges[i].Item2;

            if (nextStart <= currentEnd + 1)
            {
                if (nextEnd > currentEnd)
                    currentEnd = nextEnd;
            }
            else
            {
                merged.Add(new Tuple<long, long>(currentStart, currentEnd));
                currentStart = nextStart;
                currentEnd = nextEnd;
            }
        }
        merged.Add(new Tuple<long, long>(currentStart, currentEnd));
        return merged;
    }
}