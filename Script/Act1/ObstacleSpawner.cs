using Godot;
using System;

public partial class ObstacleSpawner : Node
{
    // L'utilisation des ExportGroup rend l'inspecteur Godot beaucoup plus lisible.
    [ExportGroup("Obstacle ref")]
    [Export] private PackedScene singleObstacleSceneRef;
    [Export] private PackedScene doubleObstacleSceneRef;
    [Export] private PackedScene tripleObstacleSceneRef;
    [Export] private PackedScene flyingObstacleSceneRef;

    [ExportGroup("Spawn point")]
    [Export] private Marker2D groundSpawnPointRef;
    [Export] private Marker2D flyingSpawnPointRef;

    [Export] private Node2D obstacleContainerRef;
    [Export] ObstacleSpawnTimer obstacleSpawnTimerRef;

    [ExportGroup("Spawn proba")] //Proba for each type of obstacle
    [Export] private float probaSingle = 40f;
    [Export] private float probaDouble = 30f;
    [Export] private float probaTriple = 20f;
    [Export] private float probaFlying = 10f;

    private float totalProba;

    public override void _Ready()
    {
        totalProba = probaSingle + probaDouble + probaTriple + probaFlying;
        obstacleSpawnTimerRef.OnSpawnTimer += SpawnObstacle;

    }

    private void SpawnObstacle()
    {
        // Determin wich obstacle will be spawned
        float lObstacleId = (float)GD.RandRange(0.0, totalProba);

        PackedScene lCurrentScene;
        Marker2D lCurrentSpawn;

        if (lObstacleId <= probaSingle)
        {
            lCurrentScene = singleObstacleSceneRef;
            lCurrentSpawn = groundSpawnPointRef;
        }
        else if (lObstacleId <= probaSingle + probaDouble)
        {
            lCurrentScene = doubleObstacleSceneRef;
            lCurrentSpawn = groundSpawnPointRef;
        }
        else if (lObstacleId <= probaSingle + probaDouble + probaTriple)
        {
            lCurrentScene = tripleObstacleSceneRef;
            lCurrentSpawn = groundSpawnPointRef;
        }
        else
        {
            lCurrentScene = flyingObstacleSceneRef;
            lCurrentSpawn = flyingSpawnPointRef;
        }

        Node2D lObstacle = (Node2D)lCurrentScene.Instantiate();
        obstacleContainerRef.AddChild(lObstacle);

        lObstacle.GlobalPosition = lCurrentSpawn.GlobalPosition;
    }
}