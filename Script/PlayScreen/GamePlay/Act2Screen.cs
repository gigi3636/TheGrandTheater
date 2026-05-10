using Godot;
using System;

public partial class Act2Screen : GameplayScreen
{
    [Export] private ArrowSpawner arrowSpawnerRef;
    [Export] private TrajectoryShower trajectoryShowerRef;
    protected override IPlayerAction ReturnPlayerAction()
    {
        PlayerAct2MiniGame lCurrentPlayerAction = new PlayerAct2MiniGame(playerControllerRef);
        lCurrentPlayerAction.OnPlayerShot += arrowSpawnerRef.SpawnArrow;
        lCurrentPlayerAction.OnPlayerAiming += trajectoryShowerRef.DrawTrajectory;
        lCurrentPlayerAction.OnPlayerStopAiming += trajectoryShowerRef.ClearTrajectory;

        return lCurrentPlayerAction;
    }
}
    