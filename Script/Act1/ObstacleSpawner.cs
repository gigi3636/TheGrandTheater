using Godot;
using System;

public partial class ObstacleSpawner : Node
{
    [Export] private PackedScene obstacleSceneRef;
    [Export] private Godot.Marker2D[] obstacleSpawnPointRef;
	[Export] private Node2D obstacleContainerRef;

    private const float SPAWN_COOLDOWN = 1f;

    private Timer spawnTimer;

    public override void _Ready()
	{
        spawnTimer = new Timer();
        spawnTimer.WaitTime = SPAWN_COOLDOWN;
        spawnTimer.OneShot = false;
        AddChild(spawnTimer);
        spawnTimer.Timeout += SpawnObstacle;
        spawnTimer.Start();

    }

    private void SpawnObstacle()
    {
        Node2D lObstacle = (Node2D)obstacleSceneRef.Instantiate();
        obstacleContainerRef.AddChild(lObstacle);
        lObstacle.GlobalPosition = obstacleSpawnPointRef[GD.RandRange(0, obstacleSpawnPointRef.Length - 1)].GlobalPosition;

    }
}
