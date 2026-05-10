using Godot;
using System;

public partial class GameplayScreen : PlayScreen
{
    [Export] protected PlayerController playerControllerRef;
    protected IPlayerAction playerAction;

    public override void _Ready()
    {
        playerControllerRef.ChangePlayerAction(ReturnPlayerAction());
    }

    protected virtual IPlayerAction ReturnPlayerAction()
    {
        return null;
    }

    public override void StartPlay()
    {
    }
}
