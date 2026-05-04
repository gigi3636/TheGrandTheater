using Godot;
using System;

public partial class Act1LevelFinisher : Node
{
    [Export] private Act1LevelTimer levelTimer;

    public override void _Ready()
    {
        levelTimer.Act1Finished += OnTimerFinishedReceived;
    }

    private void OnTimerFinishedReceived()
    {
        GD.Print("Close this act well done !");
    }
}
