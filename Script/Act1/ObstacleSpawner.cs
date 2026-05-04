using Godot;
using System;

public partial class ObstacleSpawner : Node
{
    [Export] private PackedScene obstacleSceneRef;

	[Export] private Marker2D obstacleSpawnPointRef1;
	[Export] private Marker2D obstacleSpawnPointRef2;
	[Export] private Marker2D obstacleSpawnPointRef3;

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

    public override void _Process(double delta)
    {
    }

    private void SpawnObstacle()
    {
        Act1Obstacle lObstacle = (Act1Obstacle)obstacleSceneRef.Instantiate();
        obstacleContainerRef.AddChild(lObstacle);
        int lRandom = GD.RandRange(1, 3);
        if (lRandom == 1) lObstacle.GlobalPosition = obstacleSpawnPointRef1.GlobalPosition;
        else if (lRandom == 2) lObstacle.GlobalPosition = obstacleSpawnPointRef2.GlobalPosition;
        else lObstacle.GlobalPosition = obstacleSpawnPointRef3.GlobalPosition;

    }
}
