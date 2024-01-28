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

    private void QuitCommand()
    {
        CloseAfterArgs = true;
    }
}