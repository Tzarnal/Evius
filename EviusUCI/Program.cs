using EviusUCI.Shell;
using System.Diagnostics;

//Debugger.Launch();

//Remove old log
File.Delete("log.txt");

//Setup Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Verbose()
    //.WriteTo.Console()
    .WriteTo.File("log.txt")
    .CreateLogger();

//Instantiate UCI Shell and handoff execution
EviusUCIShell shell = new();
shell.Run();