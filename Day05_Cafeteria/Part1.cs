using Common.Interfaces;
using Common.Services;

namespace Day05_Cafeteria;

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
        var ranges = GetInput(input, 0);
        var ids = GetInput(input, ranges.Count + 1);

        var total = 0;

        for (int i = 0; i < ids.Count; i++)
        {
            var id = long.Parse(ids[i]);
            if (ranges.Exists(r => long.Parse(r.Split('-')[0]) <= id && long.Parse(r.Split('-')[1]) >= id))
                total++;
        }
        return total.ToString();
    }

    private static List<string> GetInput(string[] fullInput, int startIndex)
    {
        List<string> items = [];
        for (int i = startIndex; i < fullInput.Length; i++)
        {
            if (fullInput[i] == string.Empty)
                break;

            items.Add(fullInput[i]);
        }
        return items;
    }
}
