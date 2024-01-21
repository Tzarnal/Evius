namespace EviusUCI.Shell;

internal class EviusUCIShell
{
    private bool _running;

    public void Run()
    {
        _running = true;

        while (_running)
        {
            var consoleLine = Console.ReadLine();

            Log.Information("Received {line}", consoleLine);

            if (string.IsNullOrWhiteSpace(consoleLine))
            {
                continue;
            }

            var commandElements = consoleLine.Split(" ");

            switch (commandElements[0].ToLower())
            {
                case "uci":
                    CommandUci();
                    break;

                case "isready":
                    CommandIsReady();
                    break;

                case "go":
                    CommandGo(consoleLine);
                    break;

                case "stop":
                    //stop calculating as fast as possible
                    //Expected response: bestmove <move>
                    break;

                case "ucinewgame":
                    //setup a new game, no expected response
                    break;

                case "position":
                    //receive a position
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
    }

    private void CommandGo(string input)
    {
        Console.WriteLine("bestmove a2a3");
        Log.Warning("Sent {line}", "bestmove a2a3");
    }

    private void CommandUci()
    {
        Console.WriteLine("id name Evius");
        Console.WriteLine("id author Stefan van Oudenaarden");
        Console.WriteLine("uciok");
        Log.Warning("Sent {line}", "uciok");
    }

    private void CommandIsReady()
    {
        Console.WriteLine("readyok");
        Log.Warning("Sent {line}", "readyok");
    }

    private void CommandQuit()
    {
        _running = false;
        Log.Warning("Quitting");
    }

    private void CommandDefault()
    {
        Console.WriteLine("Evius: This is a UCI interface for the Evius chessbot, use quit to exit.");
    }
}