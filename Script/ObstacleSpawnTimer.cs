using Godot;
using System;

public partial class ObstacleSpawnTimer : Node
{
    [Export] private float spawnMinCooldown = 1.5f;
    [Export] private float spawnMaxCooldown = 1.6f;

    [Export] private SpawnerProgressionDataRes spawnerProgressionData;

    private float spawnCooldown ;

    public Action OnSpawnTimer;

    private Timer spawnTimer;


    public override void _Ready()
	{
        spawnTimer = new Timer();
        spawnTimer.WaitTime = GD.RandRange(spawnMinCooldown, spawnMaxCooldown);
        spawnTimer.OneShot = true;
        AddChild(spawnTimer);
        spawnTimer.Timeout += SpawnTimerFinished;
        spawnTimer.Start();


    }

    private void SpawnTimerFinished()
    {
        OnSpawnTimer?.Invoke();

        // Setup new timer range 
        float lNewMinCooldown = spawnMinCooldown * spawnerProgressionData.currentSpeedMultiplier;
        float lNewMaxCooldown = spawnMaxCooldown * spawnerProgressionData.currentSpeedMultiplier;

        spawnTimer.WaitTime = GD.RandRange(lNewMinCooldown, lNewMaxCooldown);
        spawnTimer.Start();
    }
}
