using Common.Interfaces;
using Common.Services;

namespace Day06_TrashCompactor;

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
        var problems = GetInput(input);
        long total = 0;

        foreach (var problem in problems)
        {
            long subTotal = 0;
            if (problem.Operator == "+")
            {
                foreach (var number in problem.Operations)
                {
                    subTotal += number;
                }
            }
            else if (problem.Operator == "*")
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

        for (int i = 0; i < input.Length; i++)
        {
            if (i < input.Length - 1)
            {
                var numbers = input[i].Split(' ')
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i == 0)
                    {
                        problems.Add(new Problem());
                    }
                    problems[j].Operations.Add(numbers[j]);
                }
            }
            else
            {
                var operators = input[i].Split(' ')
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .ToArray();

                for (int j = 0; j < operators.Length; j++)
                {
                    problems[j].Operator = operators[j];
                }
            }
        }
        return problems;
    }

    internal class Problem
    {
        public List<int> Operations { get; set; } = [];
        public string Operator { get; set; } = string.Empty;
    }
}