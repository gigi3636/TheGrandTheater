using Godot;
using System;

public partial class PlayerAct3MiniGame : IPlayerAction
{
    private PlayerController playerControllerRef;

    private bool isMovingRight;
    private bool isMoving;
    private float speed = 200f;
    private Vector2 direction;
    private Marker2D columnMaxLeftRef;
    private Marker2D columnMaxRightRef;

    public PlayerAct3MiniGame(PlayerController pPlayerControllerRef, Marker2D pColumnMaxLeftRef, Marker2D pColumnMaxRightRef)
    {
        playerControllerRef = pPlayerControllerRef;
        isMovingRight = true;
        columnMaxLeftRef = pColumnMaxLeftRef;
        columnMaxRightRef = pColumnMaxRightRef;
    }


    public void OnButtonPressed()
    {
        isMoving = true;
        direction = isMovingRight ? Vector2.Right : Vector2.Left; // Switch the direction

    }

    public void OnButtonReleased()
    {
        isMoving = false;
        isMovingRight = !isMovingRight;

    }

    public void OnButtonIdle() { } 

    public void Update(float pDelta)
    {
        if (isMoving)
        {
            playerControllerRef.GlobalPosition += direction * speed * pDelta;

            if (playerControllerRef.GlobalPosition >= columnMaxRightRef.GlobalPosition || playerControllerRef.GlobalPosition <= columnMaxLeftRef.GlobalPosition)
            {
                isMovingRight = !isMovingRight;
                direction = isMovingRight ? Vector2.Right : Vector2.Left; // Switch the direction

            }
        }
    }

}
