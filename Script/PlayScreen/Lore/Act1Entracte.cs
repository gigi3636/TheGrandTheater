using Godot;
using System;

public partial class Act1Entracte : IddleScreen
{
    public override void _Ready()
    {
        base._Ready();
        StartNewDialogue(TextKeys.AccueilHappy);
    }

}
