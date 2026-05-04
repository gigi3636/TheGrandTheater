using Godot;
using System;

public partial class Act1Obstacle : Area2D
{
    public void _on_area_entered(Node2D pIntruder)
    {
        if (pIntruder is PlayerCollision pPlayer)
        {
            pPlayer.PlayerHit();
        }
    }
}
