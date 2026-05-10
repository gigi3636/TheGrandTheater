using Godot;
using System;

public partial class PlayerAct1MiniGame : IPlayerAction
{
    private const float JUMP_FORCE = -1600f;
    private const float MIN_JUMP_VELOCITY = -600f;
    private const float GRAVITY_MULTIPLIER = 5.0f;

    private PlayerController playerControllerRef;
    private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public PlayerAct1MiniGame(PlayerController pPlayerControllerRef)
    {
        playerControllerRef = pPlayerControllerRef;
    }

    public void OnButtonPressed()
    {
        if (playerControllerRef.IsOnFloor())
        {
            Vector2 lVelocity = playerControllerRef.Velocity;
            lVelocity.Y = JUMP_FORCE;
            playerControllerRef.Velocity = lVelocity;
        }
    }

    public void OnButtonReleased()
    {
        Vector2 lVelocity = playerControllerRef.Velocity;
        if (lVelocity.Y < MIN_JUMP_VELOCITY && !playerControllerRef.IsOnFloor())
        {
            lVelocity.Y = MIN_JUMP_VELOCITY;
            playerControllerRef.Velocity = lVelocity;
        }
    }

    public void OnButtonIdle() { }

    public void Update(float pDelta)
    {
        Vector2 lVelocity = playerControllerRef.Velocity;

        if (!playerControllerRef.IsOnFloor())
        {
            lVelocity.Y += (gravity * GRAVITY_MULTIPLIER) * pDelta;
        }

        playerControllerRef.Velocity = lVelocity;
    }
}