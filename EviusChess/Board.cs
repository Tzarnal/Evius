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
    private Piece[] _squares;
    public int BoardWidth { get; }
    public int BoardHeight { get; }
    public int? EnPassantSquare { get; set; }
    public int HalfmoveClock { get; set; }
    public int FullMoveCount { get; set; }
    public bool WhiteToMove { get; set; }
    public bool BlackToMove { get => !WhiteToMove; set => WhiteToMove = !value; }

    public Board(int width = 8, int height = 8)
    {
        BoardWidth = width;
        BoardHeight = height;

        var totalSquares = width * height;
        _squares = new Piece[totalSquares];
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

    public int Mailbox(string input)
    {
        var (x, y) = Utils.SplitNotation(input);
        return Mailbox(x, y);
    }

    public IEnumerable<Piece> GetAllPieces()
    {
        for (int i = 0; i < _squares.Length; i++)
        {
            if (_squares[i] != null)
            {
                yield return _squares[i];
            }
        }
    }

    public IEnumerable<Piece> GetAllWhitePieces()
    {
        foreach (var piece in GetAllPieces())
        {
            if (piece.IsWhite) yield return piece;
        }
    }

    public IEnumerable<Piece> GetAllBlackPieces()
    {
        foreach (var piece in GetAllPieces())
        {
            if (piece.IsBlack) yield return piece;
        }
    }

    public IEnumerable<T> GetPieces<T>()
    {
        foreach (var piece in GetAllPieces())
        {
            if (piece is T)
            {
                yield return (T)Convert.ChangeType(piece, typeof(T));
            }
        }
    }

    public IEnumerable<T> GetWhitePieces<T>()
    {
        foreach (var piece in GetAllWhitePieces())
        {
            if (piece is T)
            {
                yield return (T)Convert.ChangeType(piece, typeof(T));
            }
        }
    }

    public IEnumerable<T> GetBlackPieces<T>()
    {
        foreach (var piece in GetAllBlackPieces())
        {
            if (piece is T)
            {
                yield return (T)Convert.ChangeType(piece, typeof(T));
            }
        }
    }

    public Piece this[int i]
    {
        get => _squares[i];
        set => _squares[i] = value;
    }

    public Piece this[int x, int y]
    {
        get => _squares[Mailbox(x, y)];
        set => _squares[Mailbox(x, y)] = value;
    }

    public Piece this[string x, int y]
    {
        get => _squares[Mailbox(x, y)];
        set => _squares[Mailbox(x, y)] = value;
    }

    public Piece this[char x, int y]
    {
        get => _squares[Mailbox(x, y)];
        set => _squares[Mailbox(x, y)] = value;
    }

    public Piece this[string input]
    {
        get
        {
            var (x, y) = Utils.SplitNotation(input);
            return _squares[Mailbox(x, y)];
        }
        set
        {
            var (x, y) = Utils.SplitNotation(input);
            _squares[Mailbox(x, y)] = value;
        }
    }
}