namespace EviusChess.GamePieces;

public class QueenInformation : IPieceInformation
{
    public string Name => "Queen";
    public string Letter => "Q";

    public IEnumerable<MoveType> MoveTypes => [MoveType.SlideDiagonals, MoveType.SlideCardinals];
    public IEnumerable<MoveType> TakeTypes => [MoveType.SlideDiagonals, MoveType.SlideCardinals];
    public IEnumerable<MoveType> SpecialMoveTypes => [];
}

public class Queen : Piece
{
}