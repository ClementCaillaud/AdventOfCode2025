using Common.Interfaces;
using Common.Services;

namespace Day01_SecretEntrance;

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

        var dialValue = 50;
        var nbOfZeros = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var directionLetter = input[i][0];
            var distance = int.Parse(input[i].Replace("R", "").Replace("L", ""));

            if (directionLetter == 'R')
            {
                dialValue += distance;
                if (dialValue >= 100)
                {
                    int overflow = dialValue / 100;
                    dialValue -= overflow * 100;
                }
            }
            else if (directionLetter == 'L')
            {
                dialValue -= distance;
                if (dialValue < 0)
                {
                    int overflow = dialValue / 100;
                    dialValue -= overflow * 100;
                }
            }
            if (dialValue == 0)
                nbOfZeros++;
        }
        return nbOfZeros.ToString();
    }
}
