using System.Text.RegularExpressions;

namespace EviusChess.Board;

public static class BoardFactory
{
    public static Board EmptyBoard()
    {
        return new Board();
    }

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

        board.FullMoveCount = 1;

        return board;
    }

    public static Board FromFen(string Fen)
    {
        const string FenMatchRegex = "\\s*^(((?:[rnbqkpRNBQKP1-8]+\\/){7})[rnbqkpRNBQKP1-8]+)\\s([b|w])\\s(-|[K|Q|k|q]{1,4})\\s(-|[a-h][1-8])\\s(\\d+\\s\\d+)$";
        var FenMatch = Regex.Match(Fen, FenMatchRegex);

        if (!FenMatch.Success)
        {
            throw new Exception("Not a fen string");
        }

        var board = new Board();

        //Piece Placement
        FenPiecePlacement(board, FenMatch.Groups[1].Value);

        //Active Color
        var activeColor = FenMatch.Groups[3].Value;
        if (activeColor == "w")
        {
            board.WhiteToMove = true;
        }
        else if (activeColor == "b")
        {
            board.BlackToMove = true;
        }
        else
        {
            throw new Exception("Invalid argument for active colour");
        }

        //Castling
        var castlingRights = FenMatch.Groups[4].Value;
        FenCastleRights(board, castlingRights);

        //En Passant
        var enpassantSquare = FenMatch.Groups[5].Value;
        if (enpassantSquare != "-")
        {
            var (x, y) = Utils.SplitNotation(enpassantSquare);
            board.EnPassantSquare = board.Mailbox(x, y);
        }

        //Halfmove clock
        var clocks = FenMatch.Groups[6].Value.Split(" ");

        var halfMove = clocks[0];
        if (halfMove != "-")
        {
            board.HalfmoveClock = int.Parse(halfMove);
        }

        //Fullmove number
        var fullMove = clocks[1];
        if (fullMove != "-")
        {
            board.FullMoveCount = int.Parse(fullMove);
        }

        return board;
    }

    private static void FenPiecePlacement(Board Board, string PiecePlacementString)
    {
        int x = 1;
        int y = 8;

        foreach (var c in PiecePlacementString)
        {
            switch (c)
            {
                //Pieces, lowercase for black, uppercase for white
                case 'r':
                    Board[x, y] = new Rook { IsBlack = true };
                    break;

                case 'R':
                    Board[x, y] = new Rook { IsWhite = true };
                    break;

                case 'n':
                    Board[x, y] = new Knight { IsBlack = true };
                    break;

                case 'N':
                    Board[x, y] = new Knight { IsWhite = true };
                    break;

                case 'b':
                    Board[x, y] = new Bishop { IsBlack = true };
                    break;

                case 'B':
                    Board[x, y] = new Bishop { IsWhite = true };
                    break;

                case 'q':
                    Board[x, y] = new Queen { IsBlack = true };
                    break;

                case 'Q':
                    Board[x, y] = new Queen { IsWhite = true };
                    break;

                case 'k':
                    Board[x, y] = new King { IsBlack = true };
                    break;

                case 'K':
                    Board[x, y] = new King { IsWhite = true };
                    break;

                case 'p':
                    Board[x, y] = new Pawn { IsBlack = true };
                    break;

                case 'P':
                    Board[x, y] = new Pawn { IsWhite = true };
                    break;

                //Advance "down" one rank, start from "before" A so normal increment puts it on A
                case '/':
                    x = 0;
                    y--;
                    break;

                //Skip x places
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                    var skipNumber = int.Parse(c.ToString());
                    x += skipNumber - 1;
                    break;

                default:
                    throw new Exception("Uknown character in FEN string.");
            }

            x++;
        }
    }

    private static void FenCastleRights(Board board, string rights)
    {
        //No pieces have castling rights
        if (rights != "-")
        {
            foreach (var rook in board.GetPieces<Rook>())
            {
                rook.HasCastleRights = false;
            }

            foreach (var king in board.GetPieces<King>())
            {
                king.HasCastleRights = false;
            }
        }

        if (rights.Contains('Q'))
        {
            ((Rook)board["A1"]).HasCastleRights = true;
            ((King)board["E1"]).HasCastleRights = true;
        }
        else if (board["A1"] is not null and Rook)
        {
            ((Rook)board["A1"]).HasCastleRights = false;
        }

        if (rights.Contains('K'))
        {
            ((Rook)board["H1"]).HasCastleRights = true;
            ((King)board["E1"]).HasCastleRights = true;
        }
        else if (board["H1"] is not null and Rook)
        {
            ((Rook)board["A1"]).HasCastleRights = false;
        }

        //No white castling rights remain
        if (!rights.Contains('Q') && !rights.Contains('Q'))
        {
            var king = board.GetWhitePieces<King>().First();
            king.HasCastleRights = false;

            foreach (var rook in board.GetWhitePieces<Rook>())
            {
                rook.HasCastleRights = false;
            }
        }

        if (rights.Contains('q'))
        {
            ((Rook)board["A8"]).HasCastleRights = true;
            ((King)board["E8"]).HasCastleRights = true;
        }
        else if (board["A1"] is not null and Rook)
        {
            ((Rook)board["A8"]).HasCastleRights = false;
        }

        if (rights.Contains('k'))
        {
            ((Rook)board["H8"]).HasCastleRights = true;
            ((King)board["E8"]).HasCastleRights = true;
        }
        else if (board["A1"] is not null and Rook)
        {
            ((Rook)board["H8"]).HasCastleRights = false;
        }

        //No black castling rights remain
        if (!rights.Contains('q') && !rights.Contains('k'))
        {
            var king = board.GetBlackPieces<King>().First();
            king.HasCastleRights = false;

            foreach (var rook in board.GetBlackPieces<Rook>())
            {
                rook.HasCastleRights = false;
            }
        }
    }
}