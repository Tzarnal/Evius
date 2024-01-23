namespace EviusChess.Pieces;

public abstract class Piece
{
    public abstract string Name { get; }
    public abstract string Letter { get; }

    public bool IsWhite { get; set; }

    public bool IsBlack
    {
        get => !IsWhite;
        set => IsWhite = !value;
    }
}