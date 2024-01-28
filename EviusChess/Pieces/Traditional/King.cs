namespace EviusChess.Pieces;

public class KingInformation : IPieceInformation
{
    public string Name => "King";
    public string Letter => "K";
}

public class King : Piece
{
    public bool HasCastleRights { get => !HasMoved; set => HasMoved = !value; }
}