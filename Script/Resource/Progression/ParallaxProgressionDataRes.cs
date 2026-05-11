using Godot;
using System;

public partial class ParallaxProgressionDataRes : BaseProgressionDataRes
{
    [Export] private float SCROLLING_SPEED_INCREASE = 200f;
    private float maxSpeed = 2600;

    [Export] public Vector2 parallaxScrollingSpeed { get; private set; }

    override public void IncreaseDifficulty()
    {
        float lSpeed = Math.Abs(parallaxScrollingSpeed.X) + Math.Abs(parallaxScrollingSpeed.Y);

        if (lSpeed < maxSpeed) parallaxScrollingSpeed += parallaxScrollingSpeed.Normalized() * SCROLLING_SPEED_INCREASE;

        GD.Print( parallaxScrollingSpeed);

    }
}

