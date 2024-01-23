namespace EviusChess.Pieces;

public class Rook : Piece
{
    public override string Name { get => "Rook"; }
    public override string Letter { get => "R"; }

    public bool HasCastleRights { get => !HasMoved; set => HasMoved = !value; }

    public Rook()
    {
    }
}