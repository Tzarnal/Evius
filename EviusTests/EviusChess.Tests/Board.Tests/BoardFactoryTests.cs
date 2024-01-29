using EviusChess.Board;

namespace EviusTests.EviusChess.BoardTests;

public class BoardFactoryTests
{
    [Theory]
    //White pieces
    [InlineData("A1", typeof(Rook), true)]
    [InlineData("B1", typeof(Knight), true)]
    [InlineData("C1", typeof(Bishop), true)]
    [InlineData("D1", typeof(Queen), true)]
    [InlineData("E1", typeof(King), true)]
    [InlineData("F1", typeof(Bishop), true)]
    [InlineData("G1", typeof(Knight), true)]
    [InlineData("H1", typeof(Rook), true)]
    [InlineData("A2", typeof(Pawn), true)]
    [InlineData("B2", typeof(Pawn), true)]
    [InlineData("C2", typeof(Pawn), true)]
    [InlineData("D2", typeof(Pawn), true)]
    [InlineData("E2", typeof(Pawn), true)]
    [InlineData("F2", typeof(Pawn), true)]
    [InlineData("G2", typeof(Pawn), true)]
    [InlineData("H2", typeof(Pawn), true)]
    //Black pieces
    [InlineData("A8", typeof(Rook), false)]
    [InlineData("B8", typeof(Knight), false)]
    [InlineData("C8", typeof(Bishop), false)]
    [InlineData("D8", typeof(Queen), false)]
    [InlineData("E8", typeof(King), false)]
    [InlineData("F8", typeof(Bishop), false)]
    [InlineData("G8", typeof(Knight), false)]
    [InlineData("H8", typeof(Rook), false)]
    [InlineData("A7", typeof(Pawn), false)]
    [InlineData("B7", typeof(Pawn), false)]
    [InlineData("C7", typeof(Pawn), false)]
    [InlineData("D7", typeof(Pawn), false)]
    [InlineData("E7", typeof(Pawn), false)]
    [InlineData("F7", typeof(Pawn), false)]
    [InlineData("G7", typeof(Pawn), false)]
    [InlineData("H7", typeof(Pawn), false)]
    public void StartingPositionIsCorrectstring(string position, Type? piece, bool isWhite)
    {
        var board = BoardFactory.ClassicStartingBoard();
        var p = board[position];

        Assert.Equal(p.GetType(), piece);
        Assert.Equal(p.IsWhite, isWhite);
    }

    [Fact]
    public void StartingPositionFromFen()
    {
        const string fenString = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

        var board = BoardFactory.FromFen(fenString);
        var expectedBoard = BoardFactory.ClassicStartingBoard();

        for (var i = 0; i < 64; i++)
        {
            var p = board[i];
            var e = expectedBoard[i];

            if (p == null || e == null)
            {
                Assert.Equal(e, p);
            }
            else
            {
                var expectedName = Pieces.Find(e).Name;
                var pieceName = Pieces.Find(p).Name;

                Assert.Equal(e.IsWhite, p.IsWhite);
                Assert.Equal(expectedName, pieceName);
            }
        }

        Assert.True(board.WhiteToMove);
        Assert.Null(board.EnPassantSquare);
        Assert.Equal(0, board.HalfmoveClock);
        Assert.Equal(1, board.FullMoveCount);
    }
}