using Godot;
using System;

public partial class PlayStatusRes : Resource
{
    public enum PlayStatusEnum 
    {
        IntroDialogue,
        Act1Presentation,
        Act1Gameplay,     
        Act1Conclusion,
        Act2Presentation,
        Act2Gameplay,
        Act2Conclusion,
        Intermission,    
        Act3Presentation,
        Act3Gameplay,
        Act3Conclusion
    }

    public PlayStatusEnum currentPlayStatus { get; set; }

    public void StartNewRun()
    {
        currentPlayStatus = PlayStatusEnum.Act1Gameplay;
    }

}
