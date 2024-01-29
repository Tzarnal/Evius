namespace EviusChess.Moves;

public record Move
{
    public int OriginSquare;
    public int TargetSquare;

    public required Piece MovingPiece;

    public bool IsCapture;
    public Piece? TargetPiece;

    public bool HasFollowUpMove => FollowupMoves != null;
    public IEnumerable<Move>? FollowupMoves;

    public override string ToString()
    {
        var movingPiece = MovingPiece.ToString();
        var targetSquare = Utils.IntToString(TargetSquare);
        var originSquare = Utils.IntToString(OriginSquare);

        if (IsCapture)
        {
            var targetPiece = TargetPiece.ToString();
            return $"{movingPiece} on {originSquare} takes {targetPiece} on {targetSquare}";
        }

        return $"{movingPiece} on {originSquare} to {targetSquare}";
    }
}