using Godot;
using System;

public partial class Act2Entracte : IddleScreen
{
    public override void _Ready()
    {
        base._Ready();
        StartNewDialogue(TextKeys.AccueilHappy);
    }

}
