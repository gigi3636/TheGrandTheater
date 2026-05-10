using Godot;
using System;

public partial class EnemySpawner : Node
{
    [Export] private PackedScene batScene;
    [Export] private Marker2D playerPositionRef;
    [Export] private Godot.Marker2D[] spawnPointList;
    [Export] private Node2D enemyContainerRef;
    [Export] private SpawnerProgressionDataRes spawnerProgressionDataRes;

    private RandomNumberGenerator rand = new RandomNumberGenerator();
    private Timer spawnTimer;

    public override void _Ready()
    {
        spawnTimer = new Timer();
        spawnTimer.WaitTime = spawnerProgressionDataRes.enemySpawnTimerDuration;
        spawnTimer.OneShot = true;
        enemyContainerRef.AddChild(spawnTimer);   
        spawnTimer.Timeout += SpawnEntity;
        spawnTimer.Start();

    }

    public void SpawnEntity()
    {
        Bat lBat = (Bat)batScene.Instantiate();
        AddChild(lBat);
        lBat.GlobalPosition = spawnPointList[rand.RandiRange(0, spawnPointList.Length-1)].GlobalPosition;
        lBat.Initialize(playerPositionRef.GlobalPosition);
        spawnTimer.WaitTime = spawnerProgressionDataRes.enemySpawnTimerDuration;
        spawnTimer.Start();
    }
}
