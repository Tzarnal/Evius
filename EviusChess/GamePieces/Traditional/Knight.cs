namespace EviusChess.GamePieces;

public class KnightInformation : IPieceInformation
{
    public string Name => "Knight";
    public string Letter => "N";
    public bool SeperateMoveTake => false;
    public IEnumerable<MoveType> MoveTypes => [MoveType.KnightJumps];
    public IEnumerable<MoveType> TakeTypes => [MoveType.KnightJumps];
    public IEnumerable<MoveType> SpecialMoveTypes => [];
}

public class Knight : Piece
{
}