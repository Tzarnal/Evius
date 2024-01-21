namespace EviusTests.EviusChess.BoardTests;

public class MailboxTests
{
    [Fact]
    public void A1Is0()
    {
        var board = new Board();
        var result = board.Mailbox(1, 1);

        Assert.Equal(0, result);
    }

    [Fact]
    public void A1LookupIs0()
    {
        var board = new Board();
        var result = board.Mailbox("A", 1);

        Assert.Equal(0, result);
    }

    [Fact]
    public void A2Is8()
    {
        var board = new Board();
        var result = board.Mailbox(1, 2);

        Assert.Equal(8, result);
    }

    [Fact]
    public void A2LookupIs8()
    {
        var board = new Board();
        var result = board.Mailbox('a', 2);

        Assert.Equal(8, result);
    }

    [Fact]
    public void E5Is36()
    {
        var board = new Board();
        var result = board.Mailbox(5, 5);

        Assert.Equal(36, result);
    }

    [Fact]
    public void E5LookupIs36()
    {
        var board = new Board();
        var result = board.Mailbox("e", 5);

        Assert.Equal(36, result);
    }

    [Fact]
    public void H8Is63()
    {
        var board = new Board();
        var result = board.Mailbox(8, 8);

        Assert.Equal(63, result);
    }

    [Fact]
    public void H8LookupIs63()
    {
        var board = new Board();
        var result = board.Mailbox("H", 8);

        Assert.Equal(63, result);
    }
}