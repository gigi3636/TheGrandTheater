using Godot;
using System;

public partial class GameplayScreen : PlayScreen
{
    [Export] public int actDuration { get;private set ;}

    protected Timer playTimer;

    public override void StartPlay()
    {
        playTimer = new Timer();
        AddChild(playTimer);

        playTimer.WaitTime = actDuration;
        playTimer.OneShot = true;
        playTimer.Timeout += () => EmitSignal(SignalName.OnPlayFinished);
        playTimer.Autostart = true;
    }
}
