using Godot;
using System;

public partial class Act3ObstacleSpawner : BaseSpawner
{
    [Export] private PackedScene obstacleScene;
    [Export] private Godot.Marker2D[] spawnPointList;
    [Export] private Node2D enemyContainerRef;

    private RandomNumberGenerator rand = new RandomNumberGenerator();

    protected override void SpawnObstacle()
    {
        Node2D lObstacle = (Node2D)obstacleScene.Instantiate();
        enemyContainerRef.AddChild(lObstacle);
        lObstacle.GlobalPosition = spawnPointList[rand.RandiRange(0, spawnPointList.Length - 1)].GlobalPosition;
    }
}
