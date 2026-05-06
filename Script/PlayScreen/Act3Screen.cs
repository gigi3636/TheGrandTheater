using Godot;
using System;

public partial class Act3Screen : PlayScreen
{
    [Export] private Marker2D columnMaxLeftRef;
    [Export] private Marker2D columnMaxRightRef;

    protected override IPlayerAction ReturnPlayerAction()
    {
        return new PlayerAct3MiniGame(playerControllerRef, columnMaxLeftRef , columnMaxRightRef);
    }
}
