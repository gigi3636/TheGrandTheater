using Godot;
using System;

public partial class PlayerInteractionManager : Node
{
	[Export] private PlayerCollision playerCollisionRef;
	[Export] private CurrentRunDataRes currentRunDataResRef;
	[Export] private PlayStatusRes playStatusResRef;

	public override void _Ready()
	{
		playerCollisionRef.OnCollisionDetected += PlayerGetHit;
	}

	private void PlayerGetHit()
	{
		currentRunDataResRef.RegisterNewHit(playStatusResRef.currentPlay.currentPlayStatus);

    }
}
