using EviusChess.Pieces;

namespace EviusTests.EviusChess.Pieces;

public class BasicFunctionality
{
    [Fact]
    public void IsWhite()
    {
        var p = new Pawn
        {
            IsWhite = true
        };

        Assert.True(p.IsWhite);
    }

    [Fact]
    public void IsBlack()
    {
        var p = new Pawn
        {
            IsBlack = true
        };

        Assert.True(p.IsBlack);
    }
}