using Godot;
using System;

public partial class Act1Screen : PlayScreen
{
    protected override IPlayerAction ReturnPlayerAction()
    {
        return new PlayerAct1MiniGame(playerControllerRef);
    }

}
