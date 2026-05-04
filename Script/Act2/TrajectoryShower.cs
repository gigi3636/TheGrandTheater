using Godot;
using System;
public partial class TrajectoryShower : Node
{
    [Export] private float aimDragMaxDistance = 200;
    [Export] private Marker2D shotStartPos;
    [ExportGroup("Trajectory")]
    [Export] private Line2D trajectory;
    [Export] private float trajectoryLength = 100;
    [Export] private float trajectoryPointSpacing = 10f;
    [Export] ProjectileConfigRes projectileConfig;

    private const float SIMULATION_STEP = 0.001f;

    private float gravity = (float)ProjectSettings.GetSetting("physics/2d/default_gravity");
    private float linearDamp ;
    private float shotHorizontalVelocity;

    public override void _Ready()
    {
        shotHorizontalVelocity = projectileConfig.shotPower;
        linearDamp = projectileConfig.linearDamp;
    }

    public void DrawTrajectory(float pShoteTiltAmount)
    {
        float lStep = SIMULATION_STEP;
        Vector2 lPosition = shotStartPos.GlobalPosition;
        float lTotalDistance = 0f;
        float lDistanceToNextPoint = 0;
        Vector2 lPrevPosition;
        Vector2 pShotVelocity = new Vector2(shotHorizontalVelocity, -pShoteTiltAmount);

        trajectory.ClearPoints();

        while (lTotalDistance < trajectoryLength)
        {
            if (lTotalDistance >= lDistanceToNextPoint)
            {
                lDistanceToNextPoint += trajectoryPointSpacing;
                trajectory.AddPoint(trajectory.ToLocal(lPosition));
            }

            lPrevPosition = lPosition;

            // Physics simulation
            pShotVelocity.Y += gravity * lStep;
            lPosition += pShotVelocity * lStep;
            pShotVelocity *= Mathf.Clamp(1 - linearDamp * lStep, 0, 1);

            // Ditsance accumulation
            lTotalDistance += lPrevPosition.DistanceTo(lPosition);
        }
    }

    public void ClearTrajectory()
    {
        trajectory.ClearPoints();
    }
}
