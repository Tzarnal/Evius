namespace EviusChess.Board;

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
 *  Start from a and 1, reduce to 0, 0 in Mailbox
 */

public class GameBoard
{
    private Piece[] _squares;
    public int BoardWidth { get; }
    public int BoardHeight { get; }
    public int? EnPassantSquare { get; set; }
    public int HalfmoveClock { get; set; }
    public int FullMoveCount { get; set; }
    public bool WhiteToMove { get; set; }
    public bool BlackToMove { get => !WhiteToMove; set => WhiteToMove = !value; }

    public GameBoard(int width = 8, int height = 8, bool whiteToMove = true)
    {
        BoardWidth = width;
        BoardHeight = height;

        WhiteToMove = whiteToMove;

        var totalSquares = width * height;
        _squares = new Piece[totalSquares];
    }

    public bool SquareInBounds(int square)
    {
        if (square < 0) return false;
        if (square > _squares.Length) return false;
        return true;
    }

    public string SquaretoAlgabraic(int square)
    {
        var row = (square % BoardWidth) + 1;
        var col = (square / BoardWidth) + 1;

        return $"{Utils.IntToString(row)}{col}";
    }

    public void PlayMove(Move move)
    {
        _squares[move.TargetSquare] = _squares[move.OriginSquare];
        _squares[move.OriginSquare] = null;

        move.MovingPiece.HandleMove(move.TargetSquare, move.OriginSquare);

        WhiteToMove = !WhiteToMove;

        //TODO, Counters logic
    }

    #region Mailbox

    public int Mailbox(int x, int y)
    {
        return x - 1 + (y - 1) * BoardHeight;
    }

    public int Mailbox(string x, int y)
    {
        int xNumber = Utils.LetterToInt(x);
        return Mailbox(xNumber, y);
    }

    public int Mailbox(char x, int y)
    {
        int xNumber = Utils.LetterToInt(x);
        return Mailbox(xNumber, y);
    }

    public int Mailbox(string input)
    {
        var (x, y) = Utils.SplitNotation(input);
        return Mailbox(x, y);
    }

    #endregion Mailbox

    #region Iterators

    public IEnumerable<(Piece piece, int square)> GetAllPieces()
    {
        for (int i = 0; i < _squares.Length; i++)
        {
            if (_squares[i] != null)
            {
                yield return (_squares[i], i);
            }
        }
    }

    public IEnumerable<(Piece piece, int square)> GetAllWhitePieces()
    {
        foreach (var (piece, square) in GetAllPieces())
        {
            if (piece.IsWhite) yield return (piece, square);
        }
    }

    public IEnumerable<(Piece piece, int square)> GetAllBlackPieces()
    {
        foreach (var (piece, square) in GetAllPieces())
        {
            if (piece.IsBlack) yield return (piece, square);
        }
    }

    public IEnumerable<(T piece, int square)> GetPieces<T>()
    {
        foreach (var piece in GetAllPieces())
        {
            if (piece.piece is T)
            {
                var actualPiece = (T)Convert.ChangeType(piece.piece, typeof(T));

                yield return (actualPiece, piece.square);
            }
        }
    }

    public IEnumerable<(T piece, int square)> GetWhitePieces<T>()
    {
        foreach (var piece in GetAllWhitePieces())
        {
            if (piece.piece is T)
            {
                var actualPiece = (T)Convert.ChangeType(piece.piece, typeof(T));

                yield return (actualPiece, piece.square);
            }
        }
    }

    public IEnumerable<(T piece, int square)> GetBlackPieces<T>()
    {
        foreach (var piece in GetAllBlackPieces())
        {
            if (piece.piece is T)
            {
                var actualPiece = (T)Convert.ChangeType(piece.piece, typeof(T));

                yield return (actualPiece, piece.square);
            }
        }
    }

    #endregion Iterators

    #region Accessors

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

    #endregion Accessors
}