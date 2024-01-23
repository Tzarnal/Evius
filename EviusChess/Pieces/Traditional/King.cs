namespace EviusChess.Pieces;

public class King : Piece
{
    public override string Name { get => "King"; }
    public override string Letter { get => "K"; }

    public bool HasCastleRights { get => !HasMoved; set => HasMoved = !value; }

    public King()
    {
    }
}