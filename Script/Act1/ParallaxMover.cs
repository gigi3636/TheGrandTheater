using Godot;
using System;

public partial class ParallaxMover : Node2D
{
    [Export] ParallaxBackground parallaxBackgroundRef;
    [Export] private ActProgressionDataRes actProgressionDataRes;

    public override void _Process(double pDelta)
    {
        float lDelta = (float)pDelta;

        parallaxBackgroundRef.ScrollBaseOffset += actProgressionDataRes.parallaxScrollingSpeed * lDelta;

    }
}
