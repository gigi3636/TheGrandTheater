using Godot;
using System;

public partial class PlayToEnumRes : Resource
{
    [Export] public PlayStatusRes.PlayStatusEnum playStatus { get; private set; }
    [Export] public PackedScene playScene { get; private set; }
    
}
