namespace EviusChess;

/*
 * Chess board
 *
 *    _______________
 * 8 |_|#|_|#|_|#|_|#|
 * 7 |#|_|#|_|#|_|#|_|
 * 6 |_|#|_|#|_|#|_|#|
 * 5 |#|_|#|_|#|_|#|_|
 * 4 |_|#|_|#|_|#|_|#|
 * 3 |#|_|#|_|#|_|#|_|
 * 2 |_|#|_|#|_|#|_|#|
 * 1 |#|_|#|_|#|_|#|_|
 *    a b c d e f g h
 *
 *  X axis = a,b,c,d,e,f,g,h etc
 *  Y axis = 1,2,3,4,5,6,7,8
 *
 *  Start from a and 1, reduce to 0, 0 in indexer
 */

public class Board
{
    private IPiece[] _squares;
    public int BoardWidth { get; }
    public int BoardHeight { get; }

    public Board(int width = 8, int height = 8)
    {
        BoardWidth = width;
        BoardHeight = height;

        var totalSquares = width * height;
        _squares = new IPiece[totalSquares];
    }

    public int Mailbox(int x, int y)
    {
        return (x - 1) + ((y - 1) * BoardHeight);
    }

    public int Mailbox(string x, int y)
    {
        int xNumber = Utils.ToInt(x);
        return Mailbox(xNumber, y);
    }

    public int Mailbox(char x, int y)
    {
        int xNumber = Utils.ToInt(x);
        return Mailbox(xNumber, y);
    }

    public IPiece this[int i]
    {
        get => _squares[i];
        set => _squares[i] = value;
    }

    public IPiece this[int x, int y]
    {
        get => _squares[Mailbox(x, y)];
        set => _squares[Mailbox(x, y)] = value;
    }

    public IPiece this[string x, int y]
    {
        get => _squares[Mailbox(x, y)];
        set => _squares[Mailbox(x, y)] = value;
    }

    public IPiece this[char x, int y]
    {
        get => _squares[Mailbox(x, y)];
        set => _squares[Mailbox(x, y)] = value;
    }
}