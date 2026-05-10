using Godot;
using System;

public partial class ParallaxProgressionDataRes : BaseProgressionDataRes
{
    [Export] private float SCROLLING_SPEED_INCREASE = 200f;

    [Export] public Vector2 parallaxScrollingSpeed { get; private set; }

    override public void IncreaseDifficulty()
    {
        parallaxScrollingSpeed += parallaxScrollingSpeed.Normalized() * SCROLLING_SPEED_INCREASE;
    }
}

