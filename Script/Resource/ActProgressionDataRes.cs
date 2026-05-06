using Godot;
using System;

public partial class ActProgressionDataRes : Resource
{
    private const float SCROLLING_SPEED_INCREASE = 1.50f;

    [Export] public Vector2 parallaxScrollingSpeed { get; private set; }


    public void IncreaseSpeed()
    {
        parallaxScrollingSpeed *= SCROLLING_SPEED_INCREASE;
    }
}
