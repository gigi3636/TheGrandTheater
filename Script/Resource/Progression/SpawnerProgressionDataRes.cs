using Godot;
using System;

public partial class SpawnerProgressionDataRes : BaseProgressionDataRes
{
    [Export] private float spawnIntervalMultiplier = 0.9f; // Amount reduced at each difficulty increase
    public float currentSpeedMultiplier { get; private set; }


    public override void Initialize()
    {
        currentSpeedMultiplier = 1.0f;
    }

    public override void IncreaseDifficulty()
    {
        currentSpeedMultiplier *= spawnIntervalMultiplier;
    }
}
