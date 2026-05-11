using Godot;
using System;

public partial class CurtainMover : Node
{
    [Export] private Node2D LeftCurtainRef;
    [Export] private Node2D RightCurtainRef;

    public void OpenCurtain()
    {
        RightCurtainRef.Visible = false;
        LeftCurtainRef.Visible = false;
    }

    public void CloseCurtain()
    {
        RightCurtainRef.Visible = true;
        LeftCurtainRef.Visible = true;

    }
}
