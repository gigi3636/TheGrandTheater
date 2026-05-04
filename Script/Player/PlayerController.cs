using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{
    [Export] private PlayStatusRes playStatusRef;

    private IPlayerAction currentPlayerInputAction;

    public void ChangePlayerAction(IPlayerAction pPlayerAction)
    {
        currentPlayerInputAction = pPlayerAction;
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        if (@event.IsActionPressed("click"))
        {
            currentPlayerInputAction.OnButtonPressed();
        }
        else if (@event.IsActionReleased("click"))
        {
            currentPlayerInputAction.OnButtonReleased();
        }
    }

    public override void _PhysicsProcess(double pDelta)
    {

        currentPlayerInputAction.Update((float)pDelta);
        MoveAndSlide();
    }

}
