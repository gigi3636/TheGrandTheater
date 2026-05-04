using Godot;
using System;

public partial class Arrow : RigidBody2D
{
    [Export] ProjectileConfigRes projectileConfig;
    [Export] public float RotationSpeed = 10.0f;
    [Export] public float MinimumVelocity = 20.0f;

    public void Initialize(float pShoteTiltAmount)
	{
        ApplyImpulse(new Vector2(projectileConfig.shotPower, -pShoteTiltAmount));
        LinearDamp = projectileConfig.linearDamp;
    }

    public override void _IntegrateForces(PhysicsDirectBodyState2D state)
    {
        if (state.LinearVelocity.Length() > MinimumVelocity)
        {
            float targetAngle = state.LinearVelocity.Angle();

            float newRotation = (float)Mathf.LerpAngle(Rotation, targetAngle, RotationSpeed * state.Step);

            state.Transform = new Transform2D(newRotation, state.Transform.Origin);
        }
    }
}
