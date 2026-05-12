using Godot;
using System;

public abstract partial class BaseProgressionDataRes : Resource
{
    public abstract void Initialize();
    public abstract void IncreaseDifficulty();
}