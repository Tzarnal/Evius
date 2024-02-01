namespace EviusChess.Moves;

public record MoveDirections
{
    public int North;
    public int South;
    public int East;
    public int West;

    public int NorthWest;
    public int NorthEast;
    public int SouthWest;
    public int SouthEast;
}

public record SquareData
{
    public int ToNorth;
    public int ToSouth;
    public int ToWest;
    public int ToEast;

    public int ToNorthWest;
    public int ToNorthEast;
    public int ToSouthWest;
    public int ToSouthEast;

    public bool NorthEdge;
    public bool SouthEdge;
    public bool WestEdge;
    public bool EastEdge;
}