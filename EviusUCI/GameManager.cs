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

        return $"{start}{end}".ToLower();
    }

    public void MakeUCIMoves(string[] moveSet)
    {
        var moveRegex = "\\w\\d\\w\\d\\w?";

        foreach (var move in moveSet)
        {
            switch (move)
            {
                case var r when new Regex(moveRegex).IsMatch(r):
                    MakeUCIMove(move);
                    break;

                case "startpos":
                    Board = BoardFactory.ClassicStartingBoard();
                    break;

                case "moves":
                case "position":
                    break;

                default:
                    Log.Warning("Evius got a UCI move it did not understand:", move);
                    break;
            }
        }
    }

    private void MakeUCIMove(string move)
    {
        var fromString = move.Substring(0, 2);
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

        Board.PlayMove(boardMove);
    }
}