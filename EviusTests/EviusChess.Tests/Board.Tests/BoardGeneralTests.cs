namespace EviusTests.EviusChess.BoardTests;

public class BoardGeneralTests
{
    [Theory]
    //White pieces
    [InlineData("A", 1, typeof(Rook), true)]
    [InlineData("B", 1, typeof(Knight), true)]
    [InlineData("C", 1, typeof(Bishop), true)]
    [InlineData("D", 1, typeof(Queen), true)]
    [InlineData("E", 1, typeof(King), true)]
    [InlineData("F", 1, typeof(Bishop), true)]
    [InlineData("G", 1, typeof(Knight), true)]
    [InlineData("H", 1, typeof(Rook), true)]
    [InlineData("A", 2, typeof(Pawn), true)]
    [InlineData("B", 2, typeof(Pawn), true)]
    [InlineData("C", 2, typeof(Pawn), true)]
    [InlineData("D", 2, typeof(Pawn), true)]
    [InlineData("E", 2, typeof(Pawn), true)]
    [InlineData("F", 2, typeof(Pawn), true)]
    [InlineData("G", 2, typeof(Pawn), true)]
    [InlineData("H", 2, typeof(Pawn), true)]
    //Black pieces
    [InlineData("A", 8, typeof(Rook), false)]
    [InlineData("B", 8, typeof(Knight), false)]
    [InlineData("C", 8, typeof(Bishop), false)]
    [InlineData("D", 8, typeof(Queen), false)]
    [InlineData("E", 8, typeof(King), false)]
    [InlineData("F", 8, typeof(Bishop), false)]
    [InlineData("G", 8, typeof(Knight), false)]
    [InlineData("H", 8, typeof(Rook), false)]
    [InlineData("A", 7, typeof(Pawn), false)]
    [InlineData("B", 7, typeof(Pawn), false)]
    [InlineData("C", 7, typeof(Pawn), false)]
    [InlineData("D", 7, typeof(Pawn), false)]
    [InlineData("E", 7, typeof(Pawn), false)]
    [InlineData("F", 7, typeof(Pawn), false)]
    [InlineData("G", 7, typeof(Pawn), false)]
    [InlineData("H", 7, typeof(Pawn), false)]
    public void StartingPositionIsCorrect(string letter, int number, Type? piece, bool isWhite)
    {
        var board = Board.ClassicStartingBoard();
        var p = board[letter, number];

        Assert.Equal(p.GetType(), piece);
        Assert.Equal(p.IsWhite, isWhite);
    }
}