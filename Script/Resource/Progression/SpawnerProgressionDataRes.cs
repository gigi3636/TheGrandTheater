using Godot;
using System;

public partial class SpawnerProgressionDataRes : BaseProgressionDataRes
{
    private const float SPAWN_INTERVAL_MULTIPLIER = 0.9f;

    [Export] public float enemySpawnTimerDuration { get; private set; }

    override public void IncreaseDifficulty()
    {
        enemySpawnTimerDuration *= SPAWN_INTERVAL_MULTIPLIER;
    }
}
