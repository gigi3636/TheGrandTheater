using Godot;
using Godot.NativeInterop;
using System;
using System.Collections.Generic;

public partial class PartLoader : Node
{
    // Aray to export the enum linked to a play scene
    [Export] private Godot.Collections.Array<PlayToEnumRes> playToEnum;
    [Export] private Node2D playSceneContainerRef;
    [Export] private PlayStatusRes playStatus;
    [Export] private TextSignalReceiver textSignalReceiverRef;

    // Dictionary whit Play Status Enum as KEY and packedScene as value
    public Godot.Collections.Dictionary<PlayStatusRes.PlayStatusEnum, PackedScene> playScenes { get; private set; } =
        new Godot.Collections.Dictionary<PlayStatusRes.PlayStatusEnum, PackedScene>();

    public override void _Ready()
    {
        //Transpose the array in the playScenes dictionnary 
        foreach (PlayToEnumRes pPlay in playToEnum)
        {
            playScenes.Add(pPlay.playStatus, pPlay.playScene);
        }
    }

    public void LoadNextPlay()
    {
        foreach (PlayScreen lChild in playSceneContainerRef.GetChildren())
        {
            lChild.QueueFree();
        }

        PlayScreen lScene = (PlayScreen)playScenes[playStatus.currentPlayStatus].Instantiate();
        textSignalReceiverRef.ChangePlayScreen(lScene);

        playSceneContainerRef.AddChild(lScene);
    }
}