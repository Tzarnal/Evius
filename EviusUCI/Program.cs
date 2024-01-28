using EviusUCI.Shell;

//Debugger.Launch();

//Remove old log

File.Delete("log.txt");

//Setup Serilog
Log.Logger = new LoggerConfiguration()
    //.WriteTo.Console()
    .WriteTo.File("log.txt")
    .CreateLogger();

EviusExporters.ImageExporter
    .SaveImage(BoardFactory.FromFen(
        "rnbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b KQkq - 1 2"),
        "test.png");

//Instantiate UCI Shell and handoff execution
EviusUCIShell shell = new();
shell.Run();