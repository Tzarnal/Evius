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
            var targetSquareData = _squareData[targetSquare];

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

            if (targetSquareData.NorthEdge || targetSquareData.SouthEdge)
            {
                PawnPromotionMoves(move, moves, targetSquareData);
            }
            else
            {
                moves.Add(move);
            }
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
            var targetSquareData = _squareData[targetSquare];

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

            if (targetSquareData.NorthEdge || targetSquareData.SouthEdge)
            {
                PawnPromotionMoves(move, moves, targetSquareData);
            }
            else
            {
                moves.Add(move);
            }
        }

        return moves;
    }

    public List<Move> PawnPromotionMoves(Move originalMove, List<Move> moves, SquareData squareData)
    {
        if (squareData.NorthEdge && originalMove.MovingPiece.IsWhite)
        {
            PawnPromotionMovesWhites(originalMove, moves);
        }

        if (squareData.SouthEdge && originalMove.MovingPiece.IsBlack)
        {
            PawnPromotionMovesWhites(originalMove, moves);
        }

        return moves;
    }

    public List<Move> PawnPromotionMovesWhites(Move originalMove, List<Move> moves)
    {
        moves.Add(new Move
        {
            MovingPiece = originalMove.MovingPiece,
            OriginSquare = originalMove.OriginSquare,
            TargetSquare = originalMove.TargetSquare,

            IsCapture = originalMove.IsCapture,
            TargetPiece = originalMove.TargetPiece,

            IsPromotion = true,
            ReplacementPiece = new Queen { IsWhite = true }
        });

        moves.Add(new Move
        {
            MovingPiece = originalMove.MovingPiece,
            OriginSquare = originalMove.OriginSquare,
            TargetSquare = originalMove.TargetSquare,

            IsCapture = originalMove.IsCapture,
            TargetPiece = originalMove.TargetPiece,

            IsPromotion = true,
            ReplacementPiece = new Bishop { IsWhite = true }
        });

        moves.Add(new Move
        {
            MovingPiece = originalMove.MovingPiece,
            OriginSquare = originalMove.OriginSquare,
            TargetSquare = originalMove.TargetSquare,

            IsCapture = originalMove.IsCapture,
            TargetPiece = originalMove.TargetPiece,

            IsPromotion = true,
            ReplacementPiece = new Knight { IsWhite = true }
        });

        moves.Add(new Move
        {
            MovingPiece = originalMove.MovingPiece,
            OriginSquare = originalMove.OriginSquare,
            TargetSquare = originalMove.TargetSquare,

            IsCapture = originalMove.IsCapture,
            TargetPiece = originalMove.TargetPiece,

            IsPromotion = true,
            ReplacementPiece = new Rook { IsWhite = true }
        });

        return moves;
    }

    public List<Move> PawnPromotionMovesBlack(Move originalMove, List<Move> moves)
    {
        moves.Add(new Move
        {
            MovingPiece = originalMove.MovingPiece,
            OriginSquare = originalMove.OriginSquare,
            TargetSquare = originalMove.TargetSquare,

            IsCapture = originalMove.IsCapture,
            TargetPiece = originalMove.TargetPiece,

            IsPromotion = true,
            ReplacementPiece = new Queen { IsBlack = true }
        });

        moves.Add(new Move
        {
            MovingPiece = originalMove.MovingPiece,
            OriginSquare = originalMove.OriginSquare,
            TargetSquare = originalMove.TargetSquare,

            IsCapture = originalMove.IsCapture,
            TargetPiece = originalMove.TargetPiece,

            IsPromotion = true,
            ReplacementPiece = new Bishop { IsBlack = true }
        });

        moves.Add(new Move
        {
            MovingPiece = originalMove.MovingPiece,
            OriginSquare = originalMove.OriginSquare,
            TargetSquare = originalMove.TargetSquare,

            IsCapture = originalMove.IsCapture,
            TargetPiece = originalMove.TargetPiece,

            IsPromotion = true,
            ReplacementPiece = new Knight { IsBlack = true }
        });

        moves.Add(new Move
        {
            MovingPiece = originalMove.MovingPiece,
            OriginSquare = originalMove.OriginSquare,
            TargetSquare = originalMove.TargetSquare,

            IsCapture = originalMove.IsCapture,
            TargetPiece = originalMove.TargetPiece,

            IsPromotion = true,
            ReplacementPiece = new Rook { IsBlack = true }
        });

        return moves;
    }
}