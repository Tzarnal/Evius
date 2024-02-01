using EviusChess.GamePieces;

namespace EviusChess.Moves;

public partial class MoveGenerator
{
    private MoveDirections _moveDirections;
    private SquareData[] _squareData;

    private int _boardWidth;
    private int _boardHeight;

    public MoveGenerator(int Width, int Height)
    {
        _boardHeight = Height;
        _boardWidth = Width;

        _moveDirections = CalculateDirections();
        _squareData = CalculateSquareData();
    }

    public MoveGenerator(GameBoard board)
    {
        _boardHeight = board.BoardHeight;
        _boardWidth = board.BoardWidth;

        _moveDirections = CalculateDirections();
        _squareData = CalculateSquareData();
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
                GeneratePieceMoveTakes(board, square, moves);
            }
            var pieceSpecialMoves = GeneratePieceSpecialMoves(board, square, moves);
        }
        return moves.Distinct();
    }

    public List<Move> GeneratePieceMoveTakes(GameBoard board, int square, List<Move> moves)
    {
        var piece = board[square];

        foreach (var moveType in Pieces.Find(piece).MoveTypes)
        {
            switch (moveType)
            {
            }
        }
        return moves;
    }

    public List<Move> GeneratePieceMoves(GameBoard board, int square, List<Move> moves)
    {
        var piece = board[square];

        foreach (var moveType in Pieces.Find(piece).MoveTypes)
        {
            switch (moveType)
            {
                case MoveType.PawnSlideForward:
                    TraditionalPawnMove(board, square, piece, moves);
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
                    TraditionalPawnTake(board, square, piece, moves);
                    break;
            }
        }
        return moves;
    }

    public List<Move> GeneratePieceSpecialMoves(GameBoard board, int square, List<Move> moves)
    {
        return moves;
    }

    private MoveDirections CalculateDirections()
    {
        return new()
        {
            North = _boardWidth,
            South = _boardWidth * -1,

            East = +1,
            West = -1,

            NorthWest = _boardWidth + -1,
            NorthEast = _boardWidth + +1,

            SouthWest = _boardWidth * -1 + -1,
            SouthEast = _boardWidth * -1 + +1,
        };
    }

    private SquareData[] CalculateSquareData()
    {
        var totalSquares = _boardWidth * _boardHeight;
        var squareData = new SquareData[totalSquares];

        for (int w = 0; w < _boardWidth; w++)
        {
            for (int h = 0; h < _boardHeight; h++)
            {
                var i = (h * _boardWidth) + w;

                var toNorth = _boardHeight - 1 - h;
                var toSouth = h;
                var toEast = _boardWidth - 1 - w;
                var toWest = w;

                squareData[i] = new()
                {
                    ToNorth = toNorth,
                    ToSouth = toSouth,
                    ToEast = toEast,
                    ToWest = toWest,

                    ToNorthEast = Math.Min(toNorth, toEast),
                    ToNorthWest = Math.Min(toNorth, toWest),
                    ToSouthEast = Math.Min(toSouth, toEast),
                    ToSouthWest = Math.Min(toSouth, toWest),

                    WestEdge = w == 0,
                    EastEdge = w == _boardWidth - 1,
                };
            }
        }

        return squareData;
    }
}