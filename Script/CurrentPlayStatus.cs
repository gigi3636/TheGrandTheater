using Godot;
using System;
using static PlayStatusRes;

public partial class CurrentPlayStatus 
{
    public PlayStatusEnum currentPlayStatus { get; private set; }
    public bool hasPlayedRelatedText { get; private set; }

    public CurrentPlayStatus (PlayStatusEnum lCurrentPlay )
    {
        currentPlayStatus = lCurrentPlay;
        hasPlayedRelatedText = false;
    }

    public void NextPlay()
    {
        int lStatuId = (int)currentPlayStatus;
        lStatuId++;
        currentPlayStatus = (PlayStatusEnum)lStatuId;

        hasPlayedRelatedText = false;
    }

}
