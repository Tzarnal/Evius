namespace EviusChess.GamePieces;

public interface IPieceInformation
{
    string Name { get; }
    string Letter { get; }

    IEnumerable<MoveType> MoveTypes { get; }
    IEnumerable<MoveType> TakeTypes { get; }
    IEnumerable<MoveType> SpecialMoveTypes { get; }
}

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

    public override string ToString()
    {
        var color = IsWhite ? "White" : "Black";
        return $"{color} {Pieces.Find(this).Name}";
    }
}