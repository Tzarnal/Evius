namespace EviusChess.GamePieces;

public class RookInformation : IPieceInformation
{
    public string Name => "Rook";
    public string Letter => "R";
    public bool SeperateMoveTake => false;
    public IEnumerable<MoveType> MoveTypes => [MoveType.SlideCardinals];
    public IEnumerable<MoveType> TakeTypes => [MoveType.SlideCardinals];
    public IEnumerable<MoveType> SpecialMoveTypes => [];
}

public class Rook : Piece
{
    public bool HasCastleRights { get => !HasMoved; set => HasMoved = !value; }
}