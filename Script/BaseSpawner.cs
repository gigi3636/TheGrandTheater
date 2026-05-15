using Godot;
using System;

public abstract partial class BaseSpawner : Node
{
    [Export] protected ObstacleSpawnTimer obstacleSpawnTimerRef;
    public override void _Ready()
    {
        obstacleSpawnTimerRef.OnSpawnTimer += SpawnObstacle;
    }

    protected abstract void SpawnObstacle();
}
