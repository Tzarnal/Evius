using EviusChess.Moves;
using SixLabors.ImageSharp.Drawing.Processing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace EviusUCI;

public class GameManager
{
    public GameBoard Board;
    public List<Move> Moves;
    public Move? BestMove;

    private MoveGenerator _generator;

    public GameManager()
    {
        Board = BoardFactory.ClassicStartingBoard();
        Moves = [];
        _generator = new MoveGenerator(Board);
    }

    public GameManager(string Fen)
    {
        Board = BoardFactory.FromFen(Fen);
        Moves = new List<Move>();
        _generator = new MoveGenerator(Board);
    }

    public string Go()
    {
        Moves = _generator.GenerateAllMoves(Board).ToList();
        if (Moves.Count == 0)
        {
            return "0000";
        }

        BestMove = Moves[Random.Shared.Next(Moves.Count)];

        Thread.Sleep(500);

        return Stop();
    }

    public string Stop()
    {
        if (BestMove == null)
        {
            return "a1b1";
        }

        var start = Board.SquaretoAlgabraic(BestMove.OriginSquare);
        var end = Board.SquaretoAlgabraic(BestMove.TargetSquare);
        var promotion = "";

        if (BestMove.IsPromotion && BestMove.ReplacementPiece != null)
        {
            promotion = Pieces.Find(BestMove.ReplacementPiece).Letter;
        }

        return $"{start}{end}{promotion}".ToLower();
    }

    public void MakeUCIMoves(string[] moveSet)
    {
        var moveRegex = "\\w\\d\\w\\d\\w?";

        var fullLine = string.Join(" ", moveSet);

        const string FenMatchRegex = "(((?:[rnbqkpRNBQKP1-8]+\\/){7})[rnbqkpRNBQKP1-8]+)\\s([b|w])\\s(-|[K|Q|k|q]{1,4})\\s(-|[a-h][1-8])\\s(\\d+\\s\\d+)";
        var FenMatch = Regex.Match(fullLine, FenMatchRegex);
        var fenString = "";

        if (FenMatch.Success)
        {
            fenString = FenMatch.Groups[0].Value;
            fullLine = Regex.Replace(fullLine, FenMatchRegex, "");

            moveSet = fullLine.Trim().Split(" ");
        }

        foreach (var move in moveSet)
        {
            switch (move)
            {
                case var r when new Regex(moveRegex).IsMatch(r):
                    MakeUCIMove(move);
                    break;

                case "fen":
                    Board = BoardFactory.FromFen(fenString);
                    break;

                case "startpos":
                    Board = BoardFactory.ClassicStartingBoard();
                    break;

                case "moves":
                case "position":
                    break;

                default:
                    Log.Warning("Evius got a UCI move it did not understand: {move}", move);
                    Log.Verbose("Whole moveset {moveSet}", moveSet);
                    break;
            }
        }
    }

    private void MakeUCIMove(string move)
    {
        var fromString = move[..2];
        var toString = move.Substring(2, 2);

        var promote = "";

        if (move.Length == 5)
        {
            promote = move.Substring(4);
        }

        var from = Board.Mailbox(fromString);
        var to = Board.Mailbox(toString);

        var boardMove = new Move
        {
            OriginSquare = from,
            MovingPiece = Board[from],

            TargetSquare = to,
            TargetPiece = Board[to],

            IsCapture = Board[to] != null,
        };

        if (promote != "")
        {
            boardMove.IsPromotion = true;

            switch (promote)
            {
                case "q":
                    boardMove.ReplacementPiece = new Queen { IsWhite = Board.WhiteToMove };
                    break;

                case "r":
                    boardMove.ReplacementPiece = new Rook { IsWhite = Board.WhiteToMove };
                    break;

                case "n":
                    boardMove.ReplacementPiece = new Knight { IsWhite = Board.WhiteToMove };
                    break;

                case "b":
                    boardMove.ReplacementPiece = new Bishop { IsWhite = Board.WhiteToMove };
                    break;

                default:
                    Log.Error("Uknown promotion piece: {promote}", promote);
                    break;
            }
        }

        Board.PlayMove(boardMove);
    }
}