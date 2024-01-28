using EviusCLI.Shell;

//Remove old log
File.Delete("log.txt");

//Setup Serilog
Log.Logger = new LoggerConfiguration()
    //.WriteTo.Console()
    .WriteTo.File("log.txt")
    .CreateLogger();

//Process Args
Args a = new();
a.ProcesssArgs(args);

if (a.CloseAfterArgs)
    return;

//Instantiate UCI Shell and handoff execution
CLI shell = new();
shell.Run();