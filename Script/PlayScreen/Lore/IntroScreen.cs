using Godot;
using System;

public partial class IntroScreen : IddleScreen
{
    public override void _Ready()
    {
        base._Ready();
        StartNewDialogue(TextKeys.AccueilHappy);
    }

}
