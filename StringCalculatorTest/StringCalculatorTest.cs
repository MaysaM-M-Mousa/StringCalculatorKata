namespace StringCalculatorTest;

public class StringCalculatorTest
{
    private readonly StringCalculator.StringCalculator _stringCalculator;
    public StringCalculatorTest()
    {
        _stringCalculator = new StringCalculatorImp();
    }

    [Fact]
    public void Add_EmptyString_ReturnsZero()
    {
        var result = _stringCalculator.Add("");
        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1")]
    [InlineData("200")]
    public void Add_OneNumber_ReturnsTheSameNumber(string numbers)
    {
        var result = _stringCalculator.Add(numbers);
        Assert.Equal(Int32.Parse(numbers), result);
    }

    [Fact]
    public void Add_TwoNumber_ReturnsTheSumOfTheTwoNumber()
    {
        var result = _stringCalculator.Add("1,6");
        Assert.Equal(7, result);
    }


    [Fact]
    public void Add_UnknownNumberOfNumbers_ReturnsTheSumOfNumbers()
    {
        var result = _stringCalculator.Add("1,6,3,2,1,0");
        Assert.Equal(13, result);
    }

    [Fact]
    public void Add_UnknownNumberOfNumbersWithNewLineAsDelimeterSupported_ReturnsTheSumOfNumbers()
    {
        var result = _stringCalculator.Add("1,3\n6\n8,1");
        Assert.Equal(19, result);
    }


    [Fact]
    public void Add_UnknownNumberOfNumbersWithCustomizedDelimeter_ReturnsTheSumOfNumbers()
    {
        var result = _stringCalculator.Add("//!\n2!6!9!1");
        Assert.Equal(18, result);
    }
}