namespace EviusChess.Moves;

public record MoveDirections
{
    public int BoardWidth;
    public int BoardHeight;

    public int North;
    public int South;
    public int East;
    public int West;

    public int NorthWest;
    public int NorthEast;
    public int SouthWest;
    public int SouthEast;
}

public class MoveGenerator
{
    private MoveDirections _moveDirections;

    public MoveGenerator(int Width, int Height)
    {
        _moveDirections = CalculateDirections(Width, Height);
    }

    public MoveGenerator(GameBoard board)
    {
        _moveDirections = CalculateDirections(board.BoardWidth, board.BoardHeight);
    }

    private MoveDirections CalculateDirections(int Width, int Height)
    {
        return new()
        {
            BoardHeight = Height,
            BoardWidth = Width,

            North = Width,
            South = Width * -1,

            East = +1,
            West = -1,

            NorthWest = Width + -1,
            NorthEast = Width + +1,

            SouthWest = Width * -1 + -1,
            SouthEast = Width * -1 + +1,
        };
    }

    public static IEnumerable<Move> GenerateFromBoard(GameBoard board)
    {
        var moveGenerator = new MoveGenerator(board);
        return moveGenerator.GenerateAllMoves(board);
    }

    public IEnumerable<Move> GenerateAllMoves(GameBoard board)
    {
        List<(Piece piece, int square)> piecesToMove;
        List<Move> moves = [];

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
            if (Pieces.Find(piece).SeperateMoveTake)
            {
                GeneratePieceMoves(board, square, moves);
                GeneratePieceTakes(board, square, moves);
            }
            else
            {
            }
            var pieceSpecialMoves = GeneratePieceSpecial(board, square, moves);
        }
        return moves.Distinct();
    }

    public List<Move> GeneratePieceMoves(GameBoard board, int square, List<Move> moves)
    {
        var piece = board[square];

        foreach (var moveType in Pieces.Find(piece).MoveTypes)
        {
            switch (moveType)
            {
                case MoveType.PawnSlideForward:
                    TraditionalPawnMoves.PawnMove(board, square, piece, moves, _moveDirections);
                    break;
            }
        }
        return moves;
    }

    public List<Move> GeneratePieceTakes(GameBoard board, int square, List<Move> moves)
    {
        var piece = board[square];

        foreach (var moveType in Pieces.Find(piece).TakeTypes)
        {
            switch (moveType)
            {
                case MoveType.PawnTake:
                    TraditionalPawnMoves.PawnTake(board, square, piece, moves, _moveDirections);
                    break;
            }
        }
        return moves;
    }

    public List<Move> GeneratePieceSpecial(GameBoard board, int square, List<Move> moves)
    {
        return moves;
    }
}