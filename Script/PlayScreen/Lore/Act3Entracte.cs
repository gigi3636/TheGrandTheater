using Godot;
using System;

public partial class Act3Entracte : IddleScreen
{
    public override void _Ready()
    {
        base._Ready();
        StartNewDialogue(TextKeys.AccueilHappy);
    }
}
