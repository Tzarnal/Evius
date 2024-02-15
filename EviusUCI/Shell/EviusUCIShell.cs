namespace EviusUCI.Shell;

internal class EviusUCIShell
{
    private bool _running;
    private GameManager _manager;

    public void Run()
    {
        _running = true;
        _manager = new GameManager();

        Console.WriteLine("Evius Chess UCI");

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
        Log.Information(line);
        switch (command.ToLower())
        {
            case "uci":
                CommandUci();
                break;

            case "isready":
                CommandIsReady();
                break;

            case "go":
                CommandGo(line);
                break;

            case "stop":
                CommandStop();
                break;

            case "ucinewgame":
                //setup a new game, no expected response
                _manager = new GameManager();
                break;

            case "position":
                CommandPosition(line);
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

    private void CommandGo(string input)
    {
        var response = _manager.Go();
        Console.WriteLine($"bestmove {response}");
        Log.Verbose(">>> {out}", $"bestmove {response}");
    }

    private void CommandStop()
    {
        var response = _manager.Stop();
        Console.WriteLine($"bestmove {response}");
        Log.Verbose(">>> {out}", $"bestmove {response}");
    }

    private void CommandPosition(string input)
    {
        _manager.MakeUCIMoves(input.Split(" "));
    }

    private void CommandUci()
    {
        Console.WriteLine("id name Evius");
        Console.WriteLine("id author Stefan van Oudenaarden");
        Console.WriteLine("uciok");
        Log.Verbose(">>> {out}", $"uciok");
    }

    private void CommandIsReady()
    {
        Console.WriteLine("readyok");
        Log.Verbose(">>> {out}", "readyok");
    }

    private void CommandQuit()
    {
        _running = false;
    }

    private void CommandDefault()
    {
        Console.WriteLine("Evius: This is a UCI interface for the Evius chessbot, use q or quit to exit.");
    }
}