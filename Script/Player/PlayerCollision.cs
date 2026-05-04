using Godot;
using System;

public partial class PlayerCollision : Area2D
{
    [Export] CurrentRunDataRes currentRunData;

    public override void _Ready()
    {
        currentRunData.StartNewRun(); 
    }
    public void PlayerHit()
    {
        currentRunData.RegisterNewHit(1);
    }
}
