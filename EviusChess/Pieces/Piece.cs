namespace EviusChess.Pieces;

public abstract class Piece
{
    public bool IsWhite { get; set; }

    public bool IsBlack
    {
        get => !IsWhite;
        set => IsWhite = !value;
    }

    public bool HasMoved { get; set; }

    public void HandleMove(int start, int end)
    {
        HasMoved = true;
    }
}