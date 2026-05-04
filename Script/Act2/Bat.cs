using Godot;
using System;

public partial class Bat : Node2D
{
    private Vector2 targetPosition;
    private Vector2 direction;
    private float speed = 10;

    public void Initialize(Vector2 pTargetPos)
    {
        targetPosition = pTargetPos;
        direction = pTargetPos - GlobalPosition;
        direction = direction.Normalized();
    }

    public override void _PhysicsProcess(double delta)
    {
           LookAt(targetPosition);
        GlobalPosition += direction * speed;
           
    }

    public void _on_body_entered(Node2D pIntruder)
    {
        if (pIntruder is Arrow)
            QueueFree();
    }
}
