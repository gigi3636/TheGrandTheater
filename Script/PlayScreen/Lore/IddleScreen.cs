using Godot;
using System;

public partial class IddleScreen : PlayScreen
{
    protected override IPlayerAction ReturnPlayerAction()
    {
        return new PlayerIddle(playerControllerRef);
    }


}
