namespace EviusChess.Pieces;

public class RookInformation : IPieceInformation
{
    public string Name => "Rook";
    public string Letter => "R";
}

public class Rook : Piece
{
    public bool HasCastleRights { get => !HasMoved; set => HasMoved = !value; }
}