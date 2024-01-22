namespace EviusTests.EviusChess.UtilsTests;

public class UtiltsTests
{
    [Theory]
    [InlineData("A1", 1, 1)]
    [InlineData("H8", 8, 8)]
    [InlineData("Z26", 26, 26)]
    public void SplitNotation(string input, int expectedX, int expectedY)
    {
        var (x, y) = Utils.SplitNotation(input);

        Assert.Equal(expectedX, x);
        Assert.Equal(expectedY, y);
    }
}