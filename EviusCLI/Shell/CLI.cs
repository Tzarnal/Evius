namespace EviusCLI.Shell;

internal class CLI
{
    private bool _running;

    public void Run()
    {
        _running = true;

        Console.WriteLine("Evius Chess CLI");

        Listen();
    }

    private void Listen()
    {
        while (_running)
        {
            var consoleLine = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(consoleLine))
            {
                continue;
            }

            var commandElements = consoleLine.Split(" ");

            Dispatch(commandElements[0], consoleLine);
        }
    }

    private void Dispatch(string command, string line)
    {
        switch (command)
        {
            case "h":
            case "help":
                CommandHelp();
                    break;

            case "q":
            case "quit":
            case "exit":
            case "close":
                CommandQuit();
                break;

            default:
                CommandDefault();
                break;
        }
    }

    private void CommandQuit()
    {
        _running = false;
    }

    private void CommandDefault()
    {
        Console.WriteLine("Evius: This is a UCI interface for the Evius chessbot, use q or quit to exit.");
    }

    private void CommandHelp()
    {
        Console.WriteLine("Evius: This is a CLI for the Evius chessbot, use q or quit to exit.");
    }
}