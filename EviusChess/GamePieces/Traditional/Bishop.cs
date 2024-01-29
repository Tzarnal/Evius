namespace EviusChess.GamePieces;

public class BishopInformation : IPieceInformation
{
    public string Name => "Bishop";
    public string Letter => "B";

    public IEnumerable<MoveType> MoveTypes => [MoveType.SlideDiagonals];
    public IEnumerable<MoveType> TakeTypes => [MoveType.SlideDiagonals];
    public IEnumerable<MoveType> SpecialMoveTypes => [];
}

public class Bishop : Piece
{
}