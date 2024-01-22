namespace EviusChess;

public static class BoardFactory
{
    public static Board ClassicStartingBoard()
    {
        var board = new Board();

        board["A", 1] = new Rook { IsWhite = true };
        board["B", 1] = new Knight { IsWhite = true };
        board["C", 1] = new Bishop { IsWhite = true };
        board["D", 1] = new Queen { IsWhite = true };
        board["E", 1] = new King { IsWhite = true };
        board["F", 1] = new Bishop { IsWhite = true };
        board["G", 1] = new Knight { IsWhite = true };
        board["H", 1] = new Rook { IsWhite = true };

        board["A", 2] = new Pawn { IsWhite = true };
        board["B", 2] = new Pawn { IsWhite = true };
        board["C", 2] = new Pawn { IsWhite = true };
        board["D", 2] = new Pawn { IsWhite = true };
        board["E", 2] = new Pawn { IsWhite = true };
        board["F", 2] = new Pawn { IsWhite = true };
        board["G", 2] = new Pawn { IsWhite = true };
        board["H", 2] = new Pawn { IsWhite = true };

        board["A", 8] = new Rook { IsBlack = true };
        board["B", 8] = new Knight { IsBlack = true };
        board["C", 8] = new Bishop { IsBlack = true };
        board["D", 8] = new Queen { IsBlack = true };
        board["E", 8] = new King { IsBlack = true };
        board["F", 8] = new Bishop { IsBlack = true };
        board["G", 8] = new Knight { IsBlack = true };
        board["H", 8] = new Rook { IsBlack = true };

        board["A", 7] = new Pawn { IsBlack = true };
        board["B", 7] = new Pawn { IsBlack = true };
        board["C", 7] = new Pawn { IsBlack = true };
        board["D", 7] = new Pawn { IsBlack = true };
        board["E", 7] = new Pawn { IsBlack = true };
        board["F", 7] = new Pawn { IsBlack = true };
        board["G", 7] = new Pawn { IsBlack = true };
        board["H", 7] = new Pawn { IsBlack = true };

        return board;
    }
}