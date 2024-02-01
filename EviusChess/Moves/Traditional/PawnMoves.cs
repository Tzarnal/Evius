namespace EviusChess.Moves;

public partial class MoveGenerator
{
    private List<Move> TraditionalPawnMove(GameBoard board, int square, Piece piece, List<Move> moves)
    {
        var possibleMoves = new List<int>();

        if (piece.IsWhite)
        {
            possibleMoves.Add(_moveDirections.North);
            if (!piece.HasMoved)
            {
                possibleMoves.Add(_moveDirections.North + _moveDirections.North);
            }
        }
        else
        {
            possibleMoves.Add(_moveDirections.South);
            if (!piece.HasMoved)
            {
                possibleMoves.Add(_moveDirections.South + _moveDirections.South);
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

    public List<Move> TraditionalPawnTake(GameBoard board, int square, Piece piece, List<Move> moves)
    {
        var possibleMoves = new List<int>();
        var squareData = _squareData[square];

        if (piece.IsWhite)
        {
            if (!squareData.WestEdge && !squareData.EastEdge)
            {
                possibleMoves.Add(_moveDirections.NorthEast);
                possibleMoves.Add(_moveDirections.NorthWest);
            }
            else if (squareData.WestEdge)
            {
                possibleMoves.Add(_moveDirections.NorthEast);
            }
            else if (squareData.EastEdge)
            {
                possibleMoves.Add(_moveDirections.NorthWest);
            }
        }
        else
        {
            if (!squareData.WestEdge && !squareData.EastEdge)
            {
                possibleMoves.Add(_moveDirections.SouthEast);
                possibleMoves.Add(_moveDirections.SouthWest);
            }
            else if (squareData.WestEdge)
            {
                possibleMoves.Add(_moveDirections.SouthEast);
            }
            else if (squareData.EastEdge)
            {
                possibleMoves.Add(_moveDirections.SouthWest);
            }
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