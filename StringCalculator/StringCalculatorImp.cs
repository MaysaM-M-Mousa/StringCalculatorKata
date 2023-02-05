using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator;

public class StringCalculatorImp : StringCalculator
{
    public int Add(string numbers)
    {
        var customDelimiter = GetCustomDelimeter(numbers);

        var numbersSplitted = GetNumbersSplitted(numbers, customDelimiter);

        var numbersList = GetNumbersList(numbersSplitted);

        CheckIfNumbersHasNegativeValues(numbersList);

        return GetSum(numbersList);
    }

    private string GetCustomDelimeter(string numbers)
    {
        return numbers.StartsWith("//") ? numbers[2].ToString() : "\n";
    }

    private List<List<string>> GetNumbersSplitted(string numbers, string customDelimiter)
    {
        var commaDelimiter = ",";
        var numbersSplittedWithComma = numbers.Split(commaDelimiter).ToList();

        var numbersSplittedWithCustomDelimiter = new List<List<string>>();
        numbersSplittedWithComma.ForEach(num => numbersSplittedWithCustomDelimiter.Add(num.Split(customDelimiter).ToList()));

        return numbersSplittedWithCustomDelimiter;
    }

    private List<int> GetNumbersList(List<List<string>> numbersSplitted)
    {
        var numbersList = new List<int>();

        numbersSplitted
            .SelectMany(x => x)
            .ToList()
            .ForEach(num =>
            {
                Int32.TryParse(num, out var parsedNumber);
                numbersList.Add(parsedNumber);
            });

        return numbersList;
    }

    private void CheckIfNumbersHasNegativeValues(List<int> numbers)
    {
        var negativeNumbersCount = numbers
            .Where(num => num < 0)
            .ToList()
            .Count;

        if (negativeNumbersCount > 0)
        {
            string nums = "";
            numbers.ForEach(n => nums += n.ToString() + ",");
            throw new Exception($"Negatives {nums} not allowed.");
        }
    }

    private int GetSum(List<int> numbersList)
    {
        return numbersList
            .Where(num => !IsBigNumber(num) && !IsNegativeNumber(num))
            .Sum(x => x);
    }

    private bool IsBigNumber(int num)
    {
        return num > 1000;
    }

    private bool IsNegativeNumber(int num)
    {
        return num < 0;
    }
}
