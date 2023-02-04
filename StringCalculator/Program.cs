namespace StringCalculator;

public class Program
{
    public static void Main(string[] args)
    {
        var calculator = new StringCalculatorImp();

        Console.WriteLine(calculator.Add(""));

        Console.WriteLine(calculator.Add("1,2,6,5,8"));

        Console.WriteLine(calculator.Add("1,2\n3,8"));

        Console.WriteLine(calculator.Add("//;\n1;2"));

        Console.WriteLine(calculator.Add("3,5,-8"));

        Console.WriteLine(calculator.Add("1000"));
    }
}