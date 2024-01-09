namespace EviusUCI
{
    public static class Program
    {
        private static bool _running;

        public static void Main()
        {
            _running = true;

            while (_running)
            {
                var consoleLine = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(consoleLine))
                {
                    continue;
                }

                var commandElements = consoleLine.Split("'");

                switch (commandElements[0].ToLower())
                {
                    case "uci":
                        CommandUci();
                        break;

                    case "isready":
                        CommandIsReady();
                        break;

                    case "go":
                        //start calculating from current position
                        //Expected response bestmove <move>
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

        public static void CommandUci()
        {
            Console.WriteLine("id name Evius");
            Console.WriteLine("id author Stefan van Oudenaarden");
            Console.WriteLine("uciok");
        }

        public static void CommandIsReady()
        {
            Console.WriteLine("readyok");
        }

        public static void CommandQuit()
        {
            _running = false;
        }

        public static void CommandDefault()
        {
            Console.WriteLine("Evius: This is a UCI interface for the Evius chessbot, use quit to exit.");
        }
    }
}