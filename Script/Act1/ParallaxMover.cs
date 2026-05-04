using Godot;
using System;

public partial class ParallaxMover : Node2D
{
    [Export] ParallaxBackground parallaxBackgroundRef;
    [Export] private ActProgressionDataRes actProgressionDataRes;

    public override void _Process(double pDelta)
    {
        float lDelta = (float)pDelta;

        Vector2 lScrollingMovement = new Vector2(actProgressionDataRes.parallaxScrollingSpeed, 0) * lDelta;
        parallaxBackgroundRef.ScrollBaseOffset += lScrollingMovement;

    }
}
