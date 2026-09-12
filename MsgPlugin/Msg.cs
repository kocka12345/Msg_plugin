using System;
using System.Collections.Generic;
using LabApi.Features.Wrappers;
using CommandSystem;
using LabApi.Features;
using MEC;
using LabApi.Features.Console;
using LabApi.Features.Permissions;
using LabApi.Loader.Features.Plugins;
using UnityEngine.ProBuilder.MeshOperations;
using static LabApi.Features.Console.Logger;
using LabApi.Events.Arguments;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Handlers;
using PlayerRoles;

namespace MsgPlugin;


public class MsgPlugin : Plugin
{
    // The name of the plugin
    public override string Name { get; } = "Msg";

    // The description of the plugin
    public override string Description { get; } = "This plugin tests commands, allows you to .msg admins and not trigger scp096 in tutorial.";

    // The author of the plugin
    public override string Author { get; } = "kocka12345";

    // The current version of the plugin
    public override Version Version { get; } = new Version(1, 0, 0, 1);

    // The required version of LabAPI (usually the version the plugin was built with)
    public override Version RequiredApiVersion { get; } = new (LabApiProperties.CompiledVersion);
    
    
    public override void Enable()
    {
        Info("Hello World!");
        Tutorial096.Subscribe();
        PlayerEvents.Joined += OnPlayerJoined;
    }


    public override void Disable()
    {
        PlayerEvents.Joined -= OnPlayerJoined;
        Tutorial096.Unsubscribe();
        Info("Goodbye World!");  
    }

    private static void OnPlayerJoined(PlayerJoinedEventArgs ev)
    {
        Player targetPlayer = ev.Player;
        Timing.CallDelayed(30f, () =>
        {
            if (targetPlayer.Role != RoleTypeId.Spectator)
                return;

            targetPlayer.SendBroadcast(
                $"<color=red>If you need help, type .msg <your message> in to your console</color>" +
                "<color=yellow>(the one opened by the key below esc)</color>",
                10,
                Broadcast.BroadcastFlags.Normal,
                true);
        });
    }
}


[CommandHandler(typeof(ClientCommandHandler))]
public class Msg : ICommand
{
    public string Command { get; } = "MSG"; // The command used in the console.
    public string[] Aliases { get; } = ["M"]; // The desired aliases.
    public string Description { get; } = "Message an Admin whit a question/problem."; // A small description.
    
    
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (arguments.Count == 0)
        {
            response = "You have to type your message!";
            return false;
        }

        var message = string.Join(" ", arguments);
        var senderPlayer = Player.Get(sender);
        if (senderPlayer != null)
        {
            var senderName = senderPlayer.Nickname;
            foreach (Player player in Player.ReadyList)
            
            {
                if (player.RemoteAdminAccess)
                {
                    player.SendBroadcast(
                        $"<color=white>{message}</color> - <color=yellow>{senderName}</color>",
                        10,
                        Broadcast.BroadcastFlags.Normal,
                        true);
                    response = null;
                    return true;
                }
            }
        }

        response = "No admins are available.";
        return false;
    }
    
}

       