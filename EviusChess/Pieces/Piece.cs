namespace EviusChess.Pieces;

public abstract class Piece
{
    public string Name { get; set; }
    public string Letter { get; set; }

    public bool IsWhite { get; set; }

    public bool IsBlack
    {
        get => !IsWhite;
        set => IsWhite = !value;
    }
}