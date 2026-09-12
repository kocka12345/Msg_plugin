using LabApi.Events.Arguments.Scp096Events;
using LabApi.Events.CustomHandlers;
using LabApi.Events.Handlers;
using PlayerRoles;

namespace MsgPlugin;

public abstract class Tutorial096 : CustomEventsHandler
{
    public static void Subscribe()
    {
        Scp096Events.AddingTarget += OnAddingTarget;
    }

    public static void Unsubscribe()
    {
        Scp096Events.AddingTarget -= OnAddingTarget;
    }

    private static void OnAddingTarget(Scp096AddingTargetEventArgs ev)
    {
        if (ev.Target.Role == RoleTypeId.Tutorial)
        {
            ev.IsAllowed = false;
        }
    }
}

