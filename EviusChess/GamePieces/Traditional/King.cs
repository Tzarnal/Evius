namespace EviusChess.GamePieces;

public class KingInformation : IPieceInformation
{
    public string Name => "King";
    public string Letter => "K";

    public IEnumerable<MoveType> MoveTypes =>
        [MoveType.StepDiagonals, MoveType.StepCardinals];

    public IEnumerable<MoveType> TakeTypes =>
        [MoveType.StepDiagonals, MoveType.StepCardinals];

    public IEnumerable<MoveType> SpecialMoveTypes => [MoveType.KingCastles];
}

public class King : Piece
{
    public bool HasCastleRights { get => !HasMoved; set => HasMoved = !value; }
}