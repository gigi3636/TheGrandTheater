using Godot;
using System;

public partial class ProjectileConfigRes : Resource
{
    [Export] public float shotPower { get; private set; } = 1600f;
    [Export] public float linearDamp { get; private set; } = 0.7f;

}
