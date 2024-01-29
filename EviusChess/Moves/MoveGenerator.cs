using Microsoft.VisualBasic;

namespace EviusChess.Moves;

public class MoveGenerator
{
    private int BoardWidth;
    private int BoardHeight;

    private int North;
    private int South;
    private int East;
    private int West;

    private int NorthWest;
    private int NorthEast;
    private int SouthWest;
    private int SouthEast;

    public MoveGenerator(int Width, int Height)
    {
        BoardWidth = Width;
        BoardHeight = Height;

        CalculateDirections();
    }

    public MoveGenerator(GameBoard board)
    {
        BoardWidth = board.BoardWidth;
        BoardHeight = board.BoardHeight;

        CalculateDirections();
    }

    private void CalculateDirections()
    {
        North = BoardWidth;
        South = BoardWidth * -1;
    }

    public static IEnumerable<Move> GenerateFromBoard(GameBoard board)
    {
        var moveGenerator = new MoveGenerator(board);
        return moveGenerator.GenerateAllMoves(board);
    }

    public IEnumerable<Move> GenerateAllMoves(GameBoard board)
    {
        List<(Piece piece, int square)> piecesToMove;
        IEnumerable<Move> moves = [];

        if (board.WhiteToMove)
        {
            piecesToMove = board.GetAllWhitePieces().ToList();
        }
        else
        {
            piecesToMove = board.GetAllBlackPieces().ToList();
        }

        foreach (var (piece, square) in piecesToMove)
        {
            var pieceMoves = GeneratePieceMoves(board, square);
            var pieceTakes = GeneratePieceTakes(board, square);
            var pieceSpecialMoves = GeneratePieceSpecial(board, square);

            moves = moves.Concat(pieceMoves).Concat(pieceTakes).Concat(pieceSpecialMoves);
        }

        return moves.Distinct();
    }

    public List<Move> GeneratePieceMoves(GameBoard board, int square)
    {
        List<Move> moves = [];
        var piece = board[square];

        foreach (var moveType in Pieces.Find(piece).MoveTypes)
        {
            switch (moveType)
            {
                case MoveType.PawnSlideForward:
                    PawnMove(board, square, piece, moves);
                    break;
            }
        }
        return moves;
    }

    public List<Move> GeneratePieceTakes(GameBoard board, int square)
    {
        List<Move> moves = [];

        return moves;
    }

    public List<Move> GeneratePieceSpecial(GameBoard board, int square)
    {
        List<Move> moves = [];

        return moves;
    }

    public IEnumerable<Move> PawnMove(GameBoard board, int square, Piece piece, List<Move> moves)
    {
        var possibleMoves = new List<int>();

        if (piece.IsWhite)
        {
            possibleMoves.Add(North);
            if (!piece.HasMoved)
            {
                possibleMoves.Add(North + North);
            }
        }
        else
        {
            possibleMoves.Add(South);
            if (!piece.HasMoved)
            {
                possibleMoves.Add(South + South);
            }
        }

        foreach (var possibleMove in possibleMoves)
        {
            var targetSquare = square + possibleMove;

            var outOfBounds = !board.SquareInBounds(targetSquare);
            var hasPiece = board[targetSquare] != null;

            if (outOfBounds || hasPiece)
            {
                continue;
            }

            var move = new Move
            {
                MovingPiece = piece,
                OriginSquare = square,
                TargetSquare = targetSquare,
            };

            moves.Add(move);
        }

        return moves;
    }
}