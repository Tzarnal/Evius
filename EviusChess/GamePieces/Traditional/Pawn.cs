namespace EviusChess.GamePieces;

public class PawnInformation : IPieceInformation
{
    public string Name => "Pawn";
    public string Letter => "P";
    public bool SeperateMoveTake => true;
    public IEnumerable<MoveType> MoveTypes => [MoveType.PawnSlideForward];
    public IEnumerable<MoveType> TakeTypes => [MoveType.PawnTake];
    public IEnumerable<MoveType> SpecialMoveTypes => [MoveType.PawnEnPassant];
}

public class Pawn : Piece
{
}