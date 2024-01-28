namespace EviusChess.Pieces;

public interface IPieceInformation
{
    string Name { get; }
    string Letter { get; }
}

public static class PieceInformation
{
    public static Dictionary<Type, IPieceInformation> PieceList = new()
    {
        //{ typeof(Piece), new PieceInformation() }
        { typeof(Bishop),   new BishopInformation() },
        { typeof(King),     new KingInformation() },
        { typeof(Knight),   new KnightInformation() },
        { typeof(Pawn),     new PawnInformation() },
        { typeof(Queen),    new QueenInformation() },
        { typeof(Rook),     new RookInformation() },
    };

    public static IPieceInformation Find(Piece piece)
    {
        return PieceList[piece.GetType()];
    }
}