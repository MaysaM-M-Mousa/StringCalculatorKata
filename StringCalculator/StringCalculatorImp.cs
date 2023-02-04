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

        numbersListWithCustomDelimiterSupported
            .SelectMany(x => x)
            .ToList()
            .ForEach(num =>
            {
                Int32.TryParse(num, out var result);
                sum += result;
            });

        return sum;
    }
}
