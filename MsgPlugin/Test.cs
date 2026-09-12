namespace MsgPlugin;

using System;
using CommandSystem;
using static LabApi.Features.Console.Logger;

public class Test;

    [CommandHandler(typeof(ClientCommandHandler))]
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class TestCommand : ICommand
    {
        public string Command { get; } = "Test"; // The command used in the console.
        public string[] Aliases { get; } = ["T"]; // The desired aliases.
        public string Description { get; } = "Test command"; // A small description.

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count == 0)
            {
                response = "Test run successfully, but you did not specify any arguments";
                return true; 
            }
            else
            {
                response = "This was a test " + string.Join("-", arguments); 
                Info("Test command executed - returning true!");
                return true; 
            }
        
        }
    }

