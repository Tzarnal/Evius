namespace EviusChess.GamePieces;

public static class Pieces
{
    public static Dictionary<Type, IPieceInformation> PieceList { get; } = new()
    {
        //{ typeof(Piece),  new PieceInformation() }
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