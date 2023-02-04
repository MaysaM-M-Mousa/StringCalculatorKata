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
        var numbersList = numbers.Split(",").ToList();

        var numbersListWithNewLineSupported = new List<List<string>>();
        numbersList.ForEach(num => numbersListWithNewLineSupported.Add(num.Split("\n").ToList()));
        
        var sum = 0;

        numbersListWithNewLineSupported
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
