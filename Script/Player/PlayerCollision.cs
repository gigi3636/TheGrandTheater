using Godot;
using System;

public partial class PlayerCollision : Area2D
{
    public event Action OnCollisionDetected;

    public void PlayerHit()
    {
        OnCollisionDetected?.Invoke();
    }
}
