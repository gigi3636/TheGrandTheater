using Godot;
using System;

public partial class ActeProgressionManager : Node
{
    [Export] private Godot.Collections.Array<BaseProgressionDataRes> actProgressionArray;
    [Export] private LevelTimer levelTimerRef;


    public override void _Ready()
	{
        levelTimerRef.OnIntervalReached += IncreaseDificulty;

        foreach(BaseProgressionDataRes lProgressionData in actProgressionArray)
        {
            lProgressionData.Initialize();
        }
    }



    private void IncreaseDificulty()
    {
        foreach(BaseProgressionDataRes pActProgressionAffected  in actProgressionArray)
        {
            pActProgressionAffected.IncreaseDifficulty();

        }

    }
}
