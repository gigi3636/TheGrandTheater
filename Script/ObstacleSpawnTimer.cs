using Godot;
using System;

public partial class ObstacleSpawnTimer : Node
{
    [Export] private float spawnMinCooldown = 1.5f;
    [Export] private float spawnMaxCooldown = 2f;

    [Export] private ParallaxProgressionDataRes progressionData;

    private float spawnCooldown ;
    private float initialScrollingSpeedX;

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

        // Save the initial speed to compare how much the timer have to be shorter
        initialScrollingSpeedX = Mathf.Abs(progressionData.parallaxScrollingSpeed.X);

    }

    private void SpawnTimerFinished()
    {
        OnSpawnTimer?.Invoke();

        float lCurrentMultiplier = 1f;
        float lCurrentSpeedX = Mathf.Abs(progressionData.parallaxScrollingSpeed.X);
        lCurrentMultiplier = lCurrentSpeedX / initialScrollingSpeedX;

        // Setup new timer range 
        float lNewMinCooldown = spawnMinCooldown / lCurrentMultiplier;
        float lNewMaxCooldown = spawnMaxCooldown / lCurrentMultiplier;

        spawnTimer.WaitTime = GD.RandRange(lNewMinCooldown, lNewMaxCooldown);
        spawnTimer.Start();
    }
}
