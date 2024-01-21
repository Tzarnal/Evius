namespace EviusTests.EviusChess.UtilsTests;

public class NotationConversionTests
{
    [Fact]
    public void CharAIs1()
    {
        var result = Utils.ToInt('A');

        Assert.Equal(1, result);
    }

    [Fact]
    public void CharaIs1()
    {
        var result = Utils.ToInt('a');

        Assert.Equal(1, result);
    }

    [Fact]
    public void CharAIs1Backwards()
    {
        var result = Utils.ToChar(1);

        Assert.Equal('A', result);
    }

    [Fact]
    public void StringAIs1()
    {
        var result = Utils.ToInt("A");

        Assert.Equal(1, result);
    }

    [Fact]
    public void StringaIs1()
    {
        var result = Utils.ToInt("a");

        Assert.Equal(1, result);
    }

    [Fact]
    public void StringAIs1Backwards()
    {
        var result = Utils.ToString(1);

        Assert.Equal("A", result);
    }

    [Fact]
    public void His8()
    {
        var result = Utils.ToInt("H");

        Assert.Equal(8, result);
    }

    [Fact]
    public void His8Backwards()
    {
        var result = Utils.ToString(8);

        Assert.Equal("H", result);
    }

    [Fact]
    public void Zis26()
    {
        var result = Utils.ToInt("Z");

        Assert.Equal(26, result);
    }

    [Fact]
    public void Zis26Backwards()
    {
        var result = Utils.ToString(26);
        Assert.Equal("Z", result);
    }
}