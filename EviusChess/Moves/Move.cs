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
}