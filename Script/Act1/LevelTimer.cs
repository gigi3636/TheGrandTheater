using Godot;
using System;

public partial class LevelTimer : Node
{
    [Export] private float actDuration = 120f;
    [Export] private float intervalDuration = 4f;

    public event Action OnIntervalReached;

    private Timer actTimer;
    private Timer intervalTimer;

    public override void _Ready()
    {
        actTimer = new Timer();
        actTimer.WaitTime = actDuration;
        actTimer.OneShot = true;

        actTimer.Timeout += EndAct;
        AddChild(actTimer);

        intervalTimer = new Timer();
        intervalTimer.WaitTime = intervalDuration;
        intervalTimer.OneShot = false;

        intervalTimer.Timeout += () => OnIntervalReached?.Invoke();
        AddChild(intervalTimer);

        actTimer.Start();
        intervalTimer.Start();
    }

    private void EndAct()
    {
        intervalTimer.Stop(); 

        if (GetParent() is PlayScreen lPlayScreen)
        {
            lPlayScreen.EmitSignal(PlayScreen.SignalName.OnPlayFinished);
        }
    }
}