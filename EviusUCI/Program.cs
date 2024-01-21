//Debugger.Launch();

//Remove old log
using EviusUCI.Shell;

File.Delete("log.txt");

//Setup Serilog
Log.Logger = new LoggerConfiguration()
    //.WriteTo.Console()
    .WriteTo.File("log.txt")
    .CreateLogger();

//Instantiate UCI Shell and handoff execution
EviusUCIShell shell = new();
shell.Run();