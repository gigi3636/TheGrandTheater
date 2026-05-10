using Godot;
using System;

public partial class ParallaxMover : Node2D
{
    [Export] ParallaxBackground parallaxBackgroundRef;
    [Export] private ParallaxProgressionDataRes parallaxProgressionDataRes;

    public override void _Process(double pDelta)
    {
        float lDelta = (float)pDelta;

        parallaxBackgroundRef.ScrollBaseOffset += parallaxProgressionDataRes.parallaxScrollingSpeed * lDelta;

    }
}
