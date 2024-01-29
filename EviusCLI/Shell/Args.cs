using EviusChess.Board;
using EviusChess.Moves;

namespace EviusCLI.Shell;

internal class Args
{
    public bool CloseAfterArgs;

    public void ProcesssArgs(string[] args)
    {
        foreach (string arg in args)
        {
            Dispatch(arg, args);
        }
    }

    private void Dispatch(string arg, string[] args)
    {
        switch (arg.ToLower())
        {
            case "exportimagetest":
                QuitCommand();
                break;

            case "movegentest":
                TestMoveGen();
                break;

            case "quit":
                ExportImageCommand();
                break;
        }
    }

    private static void ExportImageCommand()
    {
        EviusExporters.ImageExporter
        .SaveImage(BoardFactory.FromFen(
            "rnbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b KQkq - 1 2"),
            "test.png");
    }

    private static void TestMoveGen()
    {
        var b = BoardFactory.ClassicStartingBoard();
        var moves = MoveGenerator.GenerateFromBoard(b);
        foreach (var move in moves)
        {
            Console.WriteLine($"{move.MovingPiece} to {b.SquaretoAlgabraic(move.TargetSquare)}");
        }

        //b.BlackToMove = true;
        //moves = MoveGenerator.GenerateFromBoard(b);
        //foreach (var move in moves)
        //{
        //    Console.WriteLine($"{move.MovingPiece} to {b.SquaretoAlgabraic(move.TargetSquare)}");
        //}
    }

    private void QuitCommand()
    {
        CloseAfterArgs = true;
    }
}