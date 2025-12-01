using Common.Interfaces;
using Common.Services;

namespace Day01_SecretEntrance;

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
                    nbOfZeros += overflow;
                    if (dialValue == 0)
                        nbOfZeros--;
                }
            }
            else if (directionLetter == 'L')
            {
                bool wasZero = dialValue == 0;
                dialValue -= distance;
                if (dialValue < 0)
                {
                    int overflow = dialValue / 100;
                    dialValue += overflow * -100 + 100;
                    if (dialValue == 100)
                        dialValue = 0;
                    if (!wasZero)
                        nbOfZeros += 1 + overflow * -1;
                    else
                        nbOfZeros += overflow * -1;
                    if (dialValue == 0)
                        nbOfZeros--;
                }
            }
            if (dialValue == 0)
                nbOfZeros++;
        }
        return nbOfZeros.ToString();
    }
}
