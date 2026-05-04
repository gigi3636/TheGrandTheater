using Godot;
using System;

public partial class GameScreen : Screen
{
    [Export] private GameManager gameManagerRef;
    [Export] private Node2D gameSceneContainerRef;
    private int currentAct;

    public override void LoadScene()
    {
        base.LoadScene();
        gameManagerRef.SetupTheater();
    }

    public override void CloseScene()
    {
        base.CloseScene();

        foreach (Node lScene in gameSceneContainerRef.GetChildren())
        {
            lScene.QueueFree();
        }
    }
}
