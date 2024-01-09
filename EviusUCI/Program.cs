using Serilog;
using System.Diagnostics;

namespace EviusUCI
{
    public static class Program
    {
        private static bool _running;

        public static void Main()
        {
            //Debugger.Launch();
            File.Delete("log.txt");
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("log.txt")
                .CreateLogger();

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

        public static void CommandGo(string input)
        {
            Console.WriteLine("bestmove a2a3");
            Log.Warning("Sent {line}", "bestmove a2a3");
        }

        public static void CommandUci()
        {
            Console.WriteLine("id name Evius");
            Console.WriteLine("id author Stefan van Oudenaarden");
            Console.WriteLine("uciok");
            Log.Warning("Sent {line}", "uciok");
        }

        public static void CommandIsReady()
        {
            Console.WriteLine("readyok");
            Log.Warning("Sent {line}", "readyok");
        }

        public static void CommandQuit()
        {
            _running = false;
            Log.Warning("Quitting");
        }

        public static void CommandDefault()
        {
            Console.WriteLine("Evius: This is a UCI interface for the Evius chessbot, use quit to exit.");
        }
    }
}