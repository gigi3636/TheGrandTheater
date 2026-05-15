using Godot;
using System;

public partial class CurtrainManager : Node
{
    [Export] private ScreenManager screenManagerRef;
    [Export] private CurtainMover curtainMoverRef;
    private PartLoader partLoaderRef;

    private bool isClose;

    public void Initialize(PartLoader pPartLoaderRef)
    {
        partLoaderRef = pPartLoaderRef;
        partLoaderRef.PartLoading += ChangeCurtainState;


    }

    private void ChangeCurtainState()
    {
        if (isClose) curtainMoverRef.OpenCurtain();
        else curtainMoverRef.CloseCurtain();

        isClose = !isClose;
    }


}
