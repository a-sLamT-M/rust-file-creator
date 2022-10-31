// See https://aka.ms/new-console-template for more information

using System.CommandLine;
using RustFile.Commands;

var rootCommand = new RootCommand("Rust File Enhance");
var addCommand = new AddCommand();
rootCommand.AddCommand(addCommand.WriteCommand);
return rootCommand.InvokeAsync(args).Result;