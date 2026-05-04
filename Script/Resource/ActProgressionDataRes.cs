using Godot;
using System;

public partial class ActProgressionDataRes : Resource
{
    private const int SCROLLING_SPEED_INCREASE = -100;

    [Export] public float parallaxScrollingSpeed { get; private set; } = -500f;


    public void IncreaseSpeed()
    {
        parallaxScrollingSpeed += SCROLLING_SPEED_INCREASE;

    }
}
