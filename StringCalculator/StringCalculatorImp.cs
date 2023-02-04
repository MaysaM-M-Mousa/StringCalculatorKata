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
        var commaDelimiter = ",";
        var customDelimiter = "\n";

        if (numbers.StartsWith("//"))
        {
            customDelimiter = numbers[2].ToString();
        }

        var numbersList = numbers.Split(commaDelimiter).ToList();

        var numbersListWithCustomDelimiterSupported = new List<List<string>>();
        numbersList.ForEach(num => numbersListWithCustomDelimiterSupported.Add(num.Split(customDelimiter).ToList()));

        var sum = 0;

        var negativeNumbers = new List<int>();

        numbersListWithCustomDelimiterSupported
            .SelectMany(x => x)
            .ToList()
            .ForEach(num =>
            {
                Int32.TryParse(num, out var parsedNumber);

                if (parsedNumber < 0)
                {
                    negativeNumbers.Add(parsedNumber);
                    parsedNumber = 0;
                }

                if(parsedNumber > 1000)
                {
                    parsedNumber = 0;
                }

                sum += parsedNumber;
            });

        if (negativeNumbers.Count > 0)
        {
            string nums = "";
            negativeNumbers.ForEach(n => nums += n.ToString() + ",");
            throw new Exception($"Negatives {nums} not allowed, ");
        }

        return sum;
    }
}
