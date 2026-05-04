using Godot;
using System;

public partial class EnemySpawner : Node
{
    [Export] private Marker2D batSpawnerRef;
    [Export] private PackedScene batScene;
    [Export] private Marker2D playerPosition;
    [Export] private Godot.Marker2D[] spawnPointList;
    private RandomNumberGenerator rand = new RandomNumberGenerator();

    private Timer spawnTimer;

    public override void _Ready()
    {
        SpawnEntity();
        spawnTimer = new Timer();
        spawnTimer.WaitTime = 2f;
        spawnTimer.OneShot = false;
        AddChild(spawnTimer);   
        spawnTimer.Timeout += SpawnEntity;
        spawnTimer.Start();

    }

    public void SpawnEntity()
    {

        Bat lBat = (Bat)batScene.Instantiate();
        AddChild(lBat);
        lBat.GlobalPosition = spawnPointList[rand.RandiRange(0, 3)].GlobalPosition;
        lBat.Initialize(playerPosition.GlobalPosition);
    }
}
