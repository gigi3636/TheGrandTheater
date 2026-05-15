using Godot;
using System;

public partial class ParallaxProgressionDataRes : BaseProgressionDataRes
{
    [Export] private float SCROLLING_SPEED_INCREASE = 200f;

    public float initialParallaxScrollingSpeed { get; private set; }
    private float maxSpeed = 2600;

    [Export] public Vector2 parallaxScrollingSpeed { get; private set; }

    override public void Initialize()
    {

        initialParallaxScrollingSpeed = GetParallaxSpeed();
    }

    override public void IncreaseDifficulty()
    {

        if (GetParallaxSpeed() < maxSpeed) parallaxScrollingSpeed += parallaxScrollingSpeed.Normalized() * SCROLLING_SPEED_INCREASE;


    }

    private float GetParallaxSpeed()
    {
        float lSpeed = Math.Abs(parallaxScrollingSpeed.X) + Math.Abs(parallaxScrollingSpeed.Y);
        return lSpeed;
    }
}

