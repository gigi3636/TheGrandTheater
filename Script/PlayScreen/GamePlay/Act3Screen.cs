using Godot;
using System;

public partial class Act3Screen : GameplayScreen
{
    [Export] private Marker2D columnMaxLeftRef;
    [Export] private Marker2D columnMaxRightRef;
    [Export] private PackedScene textBubbleScene;

    protected override IPlayerAction ReturnPlayerAction()
    {
        return new PlayerAct3MiniGame(playerControllerRef, columnMaxLeftRef , columnMaxRightRef);
    }

    public override void _Ready()
    {
        base._Ready();
        TextBubble lTextBubble = (TextBubble)textBubbleScene.Instantiate();

        AddChild(lTextBubble);
        lTextBubble.Initialize(TextKeys.AccueilHappy);
    }

}
