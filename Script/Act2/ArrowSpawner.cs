using Godot;
using System;

public partial class ArrowSpawner : Node
{
    [Export] private PackedScene arrowScene;
    [Export] private Marker2D arrowShotSpawnRef;
    public void SpawnArrow(float pShoteTiltAmount)
    {
        Arrow lArrow = (Arrow)arrowScene.Instantiate();
        AddChild(lArrow);
        lArrow.GlobalPosition = arrowShotSpawnRef.GlobalPosition;
        lArrow.Initialize(pShoteTiltAmount);
    }
}