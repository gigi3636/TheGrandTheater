using Godot;
using System;

public partial class ObstacleCollision : Area2D
{
    public void _on_area_entered(Node2D pIntruder)
    {
        if (pIntruder is PlayerCollision pPlayer)
        {
            pPlayer.PlayerHit();
        }
    }
}
