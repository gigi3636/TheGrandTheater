using Godot;
using System;

public partial class PlayerAct1MiniGame : IPlayerAction
{
    private const float JUMP_MAX_INTENSITY = -2500f;
    private const float JUMP_INCREASE_VALUE = -2500f;

    private PlayerController playerControllerRef;

    private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
    private float currentJumpVelocity = 0f;

    private bool isPlayerJumping;
    private bool isPlayerCharginJump;

    public PlayerAct1MiniGame(PlayerController pPlayerControllerRef)
    {
        playerControllerRef = pPlayerControllerRef;
    }

    public void OnButtonPressed()
    {
        if (!isPlayerJumping && playerControllerRef.IsOnFloor() &&  !isPlayerCharginJump)
        {
            isPlayerCharginJump = true;
        }
    }

    public void OnButtonReleased() 
    {
        if (!isPlayerJumping && playerControllerRef.IsOnFloor() &&  isPlayerCharginJump)
        {
            isPlayerJumping = true;
            isPlayerCharginJump = false;
        }
    }

    public void OnButtonIdle() { } // Why not add stamina and using high jump use more of it and idle recup stam?

    public void Update(float pDelta)
    {
        Vector2 lVelocity = playerControllerRef.Velocity;

        if (!playerControllerRef.IsOnFloor())
            lVelocity.Y += (gravity + 5000) * pDelta;

        if (isPlayerCharginJump)
        {
            if (currentJumpVelocity > (JUMP_MAX_INTENSITY ))
            {
                currentJumpVelocity += JUMP_INCREASE_VALUE * pDelta;
            }
        }
        else if (isPlayerJumping)
        {
            lVelocity.Y = currentJumpVelocity;
            isPlayerJumping = false;
            currentJumpVelocity = 0f;
        }

        playerControllerRef.Velocity = lVelocity;
    }
}