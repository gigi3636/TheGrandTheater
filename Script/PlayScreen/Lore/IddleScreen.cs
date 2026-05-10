using Godot;
using System;

public partial class IddleScreen : PlayScreen
{
    public override void DialogueHasEnded()
    {
        EmitSignal(SignalName.OnPlayFinished);
    }
}
