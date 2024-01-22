using EviusUCI.Shell;

//Debugger.Launch();

//Remove old log

File.Delete("log.txt");

//Setup Serilog
Log.Logger = new LoggerConfiguration()
    //.WriteTo.Console()
    .WriteTo.File("log.txt")
    .CreateLogger();

//Instantiate UCI Shell and handoff execution
EviusUCIShell shell = new();
shell.Run();