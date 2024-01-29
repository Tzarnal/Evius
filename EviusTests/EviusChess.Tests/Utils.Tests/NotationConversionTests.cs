namespace EviusTests.EviusChess.UtilsTests;

public class NotationConversionTests
{
    [Fact]
    public void CharAIs1()
    {
        var result = Utils.LetterToInt('A');

        Assert.Equal(1, result);
    }

    [Fact]
    public void CharaIs1()
    {
        var result = Utils.LetterToInt('a');

        Assert.Equal(1, result);
    }

    [Fact]
    public void CharAIs1Backwards()
    {
        var result = Utils.IntToChar(1);

        Assert.Equal('A', result);
    }

    [Fact]
    public void StringAIs1()
    {
        var result = Utils.LetterToInt("A");

        Assert.Equal(1, result);
    }

    [Fact]
    public void StringaIs1()
    {
        var result = Utils.LetterToInt("a");

        Assert.Equal(1, result);
    }

    [Fact]
    public void StringAIs1Backwards()
    {
        var result = Utils.IntToString(1);

        Assert.Equal("A", result);
    }

    [Fact]
    public void His8()
    {
        var result = Utils.LetterToInt("H");

        Assert.Equal(8, result);
    }

    [Fact]
    public void His8Backwards()
    {
        var result = Utils.IntToString(8);

        Assert.Equal("H", result);
    }

    [Fact]
    public void Zis26()
    {
        var result = Utils.LetterToInt("Z");

        Assert.Equal(26, result);
    }

    [Fact]
    public void Zis26Backwards()
    {
        var result = Utils.IntToString(26);
        Assert.Equal("Z", result);
    }
}