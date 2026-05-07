using Godot;
using System;

public partial class PlayerIddle : IPlayerAction
{
    private PlayerController playerControllerRef;


    public PlayerIddle(PlayerController pPlayerControllerRef)
    {
        playerControllerRef = pPlayerControllerRef;
    }


    public void OnButtonPressed()
    {
    }

    public void OnButtonReleased()
    {
    }

    public void OnButtonIdle() { }

    public void Update(float pDelta)
    {
    }
}
