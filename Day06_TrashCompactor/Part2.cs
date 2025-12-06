using Common.Interfaces;
using Common.Services;
using System.Text;

namespace Day06_TrashCompactor;

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
        var problems = GetInput(input);
        long total = 0;

        foreach (var problem in problems)
        {
            long subTotal = 0;
            if (problem.Operator == '+')
            {
                foreach (var number in problem.Operations)
                {
                    subTotal += number;
                }
            }
            else if (problem.Operator == '*')
            {
                subTotal = 1;
                foreach (var number in problem.Operations)
                {
                    subTotal *= number;
                }
            }
            total += subTotal;
        }
        return total.ToString();
    }

    private static List<Problem> GetInput(string[] input)
    {
        List<Problem> problems = [];
        var lineLength = input[0].Length;
        var problemIndex = 0;

        for (int colIndex = 0; colIndex < lineLength; colIndex++)
        {
            var numberString = new StringBuilder();
            char operation;
            var emptyNb = 0;

            for (int lineIndex = 0; lineIndex < input.Length; lineIndex++)
            {
                if (lineIndex < input.Length - 1 && input[lineIndex][colIndex] != ' ')
                {
                    numberString.Append(input[lineIndex][colIndex]);
                }
                else if (lineIndex == input.Length - 1 && input[lineIndex][colIndex] != ' ')
                {
                    operation = input[lineIndex][colIndex];
                    problems.Add(new Problem
                    {
                        Operator = operation
                    });
                }
                else
                {
                    emptyNb++;
                }
            }

            if (emptyNb == input.Length)
            {
                problemIndex++;
            }
            else
            {
                problems[problemIndex].Operations.Add(int.Parse(numberString.ToString()));
            }
        }
        return problems;
    }

    internal class Problem
    {
        public List<int> Operations { get; set; } = [];
        public char Operator { get; set; }
    }
}