namespace StringCalculator;

public class Program
{
    public static void Main(string[] args)
    {
        var calculator = new StringCalculatorImp();

        Console.WriteLine(calculator.Add(""));
    }
}