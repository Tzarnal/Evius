namespace EviusChess.Moves;

public static class TraditionalPawnMoves
{
    public static IEnumerable<Move> PawnMove(GameBoard board, int square, Piece piece, List<Move> moves, MoveDirections d)
    {
        var possibleMoves = new List<int>();

        if (piece.IsWhite)
        {
            possibleMoves.Add(d.North);
            if (!piece.HasMoved)
            {
                possibleMoves.Add(d.North + d.North);
            }
        }
        else
        {
            possibleMoves.Add(d.South);
            if (!piece.HasMoved)
            {
                possibleMoves.Add(d.South + d.South);
            }
        }

        foreach (var possibleMove in possibleMoves)
        {
            var targetSquare = square + possibleMove;

            var outOfBounds = !board.SquareInBounds(targetSquare);
            var hasPiece = board[targetSquare] != null;

            if (outOfBounds || hasPiece)
            {
                break;
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

    public static IEnumerable<Move> PawnTake(GameBoard board, int square, Piece piece, List<Move> moves, MoveDirections d)
    {
        var possibleMoves = new List<int>();

        if (piece.IsWhite)
        {
            possibleMoves.Add(d.NorthEast);
            possibleMoves.Add(d.NorthWest);
        }
        else
        {
            possibleMoves.Add(d.SouthEast);
            possibleMoves.Add(d.SouthWest);
        }

        foreach (var possibleMove in possibleMoves)
        {
            var targetSquare = square + possibleMove;

            var outOfBounds = !board.SquareInBounds(targetSquare);
            var hasPiece = board[targetSquare] != null;
            var targetPiece = board[targetSquare];

            if (outOfBounds || !hasPiece || targetPiece.IsWhite == board.WhiteToMove)
            {
                continue;
            }

            //TODO, Checks for move across board edge weirdness

            var move = new Move
            {
                MovingPiece = piece,
                OriginSquare = square,
                TargetSquare = targetSquare,

                IsCapture = true,
                TargetPiece = board[targetSquare]
            };

            moves.Add(move);
        }

        return moves;
    }
}