using Godot;
using System;

public partial class Act2ObstacleSpawner : BaseSpawner
{
    [Export] private PackedScene batScene;
    [Export] private Marker2D playerPositionRef;
    [Export] private Godot.Marker2D[] spawnPointList;
    [Export] private Node2D enemyContainerRef;

    private RandomNumberGenerator rand = new RandomNumberGenerator();

    protected override void SpawnObstacle()
    {
        Bat lBat = (Bat)batScene.Instantiate();
        enemyContainerRef.AddChild(lBat);
        lBat.GlobalPosition = spawnPointList[rand.RandiRange(0, spawnPointList.Length-1)].GlobalPosition;
        lBat.Initialize(playerPositionRef.GlobalPosition);
    }
}
