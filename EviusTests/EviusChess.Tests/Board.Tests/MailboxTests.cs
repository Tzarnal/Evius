namespace EviusTests.EviusChess.BoardTests;

public class MailboxTests
{
    [Theory]
    [InlineData("A1", 0)]
    [InlineData("A2", 8)]
    [InlineData("E5", 36)]
    [InlineData("H7", 55)]
    [InlineData("H8", 63)]
    public void NotationMailbox(string input, int expected)
    {
        var board = new GameBoard();
        var result = board.Mailbox(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("A", 1, 0)]
    [InlineData("A", 2, 8)]
    [InlineData("E", 5, 36)]
    [InlineData("H", 8, 63)]
    public void StringIntMailbox(string x, int y, int expected)
    {
        var board = new GameBoard();
        var result = board.Mailbox(x, y);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData('A', 1, 0)]
    [InlineData('A', 2, 8)]
    [InlineData('E', 5, 36)]
    [InlineData('H', 8, 63)]
    public void CharIntMailbox(char x, int y, int expected)
    {
        var board = new GameBoard();
        var result = board.Mailbox(x, y);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 1, 0)]
    [InlineData(1, 2, 8)]
    [InlineData(5, 5, 36)]
    [InlineData(8, 8, 63)]
    public void IntIntMailbox(int x, int y, int expected)
    {
        var board = new GameBoard();
        var result = board.Mailbox(x, y);

        Assert.Equal(expected, result);
    }
}