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

    public Board(int width = 8, int height = 8)
    {
        BoardWidth = width;
        BoardHeight = height;

        var totalSquares = width * height;
        _squares = new Piece[totalSquares];
    }

    public static Board ClassicStartingBoard()
    {
        var board = new Board();

        board["A", 1] = new Rook { IsWhite = true };
        board["B", 1] = new Knight { IsWhite = true };
        board["C", 1] = new Bishop { IsWhite = true };
        board["D", 1] = new Queen { IsWhite = true };
        board["E", 1] = new King { IsWhite = true };
        board["F", 1] = new Bishop { IsWhite = true };
        board["G", 1] = new Knight { IsWhite = true };
        board["H", 1] = new Rook { IsWhite = true };

        board["A", 2] = new Pawn { IsWhite = true };
        board["B", 2] = new Pawn { IsWhite = true };
        board["C", 2] = new Pawn { IsWhite = true };
        board["D", 2] = new Pawn { IsWhite = true };
        board["E", 2] = new Pawn { IsWhite = true };
        board["F", 2] = new Pawn { IsWhite = true };
        board["G", 2] = new Pawn { IsWhite = true };
        board["H", 2] = new Pawn { IsWhite = true };

        board["A", 8] = new Rook { IsBlack = true };
        board["B", 8] = new Knight { IsBlack = true };
        board["C", 8] = new Bishop { IsBlack = true };
        board["D", 8] = new Queen { IsBlack = true };
        board["E", 8] = new King { IsBlack = true };
        board["F", 8] = new Bishop { IsBlack = true };
        board["G", 8] = new Knight { IsBlack = true };
        board["H", 8] = new Rook { IsBlack = true };

        board["A", 7] = new Pawn { IsBlack = true };
        board["B", 7] = new Pawn { IsBlack = true };
        board["C", 7] = new Pawn { IsBlack = true };
        board["D", 7] = new Pawn { IsBlack = true };
        board["E", 7] = new Pawn { IsBlack = true };
        board["F", 7] = new Pawn { IsBlack = true };
        board["G", 7] = new Pawn { IsBlack = true };
        board["H", 7] = new Pawn { IsBlack = true };

        return board;
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
}