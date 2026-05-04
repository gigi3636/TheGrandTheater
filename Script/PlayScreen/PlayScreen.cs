using Godot;
using System;

public partial class PlayScreen : Control
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

}
