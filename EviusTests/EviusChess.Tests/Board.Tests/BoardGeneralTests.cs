namespace EviusTests.EviusChess.BoardTests;

public class BoardGeneralTests
{
    [Theory]
    [InlineData("A1", typeof(Rook))]
    [InlineData("H7", typeof(Pawn))]
    public void StringIndexer(string position, Type? piece)
    {
        var board = BoardFactory.ClassicStartingBoard();
        var p = board[position];

        Assert.Equal(p.GetType(), piece);
    }

    [Theory]
    [InlineData("A", 1, typeof(Rook))]
    [InlineData("H", 7, typeof(Pawn))]
    public void StringIntIndexer(string x, int y, Type? piece)
    {
        var board = BoardFactory.ClassicStartingBoard();
        var p = board[x, y];

        Assert.Equal(p.GetType(), piece);
    }

    [Theory]
    [InlineData('A', 1, typeof(Rook))]
    [InlineData('H', 7, typeof(Pawn))]
    public void CharIntIndexer(char x, int y, Type? piece)
    {
        var board = BoardFactory.ClassicStartingBoard();
        var p = board[x, y];

        Assert.Equal(p.GetType(), piece);
    }

    [Theory]
    [InlineData(1, 1, typeof(Rook))]
    [InlineData(8, 7, typeof(Pawn))]
    public void IntIntIndexer(int x, int y, Type? piece)
    {
        var board = BoardFactory.ClassicStartingBoard();
        var p = board[x, y];

        Assert.Equal(p.GetType(), piece);
    }

    [Theory]
    [InlineData(0, typeof(Rook))]
    [InlineData(55, typeof(Pawn))]
    public void IntIndexer(int index, Type? piece)
    {
        var board = BoardFactory.ClassicStartingBoard();
        var p = board[index];

        Assert.Equal(p.GetType(), piece);
    }
}