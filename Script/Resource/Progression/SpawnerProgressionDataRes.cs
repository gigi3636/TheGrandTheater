using Godot;
using System;

public partial class SpawnerProgressionDataRes : BaseProgressionDataRes
{
    [Export] private float spawnIntervalMultiplier = 0.9f; // Amount reduced at each difficulty increase
    [Export] private float maxSpawnIntervalMultiplier = 0.5f;
    public float currentSpeedMultiplier { get; private set; }


    public override void Initialize()
    {
        currentSpeedMultiplier = 1f;

    }

    public override void IncreaseDifficulty()
    {
        if (currentSpeedMultiplier > maxSpawnIntervalMultiplier) currentSpeedMultiplier *= spawnIntervalMultiplier;

        GD.Print(currentSpeedMultiplier);

    }
}
