using Godot;
using System;

public partial class GameManager : Node
{
    [Export] CurrentRunDataRes currentRunData;
    [Export] PlayStatusRes playStatus;
    [Export] PartLoader partLoaderRef;

    public void SetupTheater()
    {
        currentRunData.StartNewRun();
        playStatus.StartNewRun();
        partLoaderRef.LoadNextPlay();

    }

    public void StartAct1()
    {
    }
}
