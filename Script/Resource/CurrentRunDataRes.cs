using Godot;
using System;
using System.Collections.Generic;

public partial class CurrentRunDataRes : Resource
{
    public Dictionary<PlayStatusRes.PlayStatusEnum, int> playerHitPerAct {  get; private set; }

    public void StartNewRun()
    {
        playerHitPerAct = new Dictionary<PlayStatusRes.PlayStatusEnum, int>();
    }

    public void RegisterNewHit(PlayStatusRes.PlayStatusEnum pCurrentPlay)
    {
        if (!playerHitPerAct.ContainsKey(pCurrentPlay)) playerHitPerAct.Add(pCurrentPlay, 0);
        playerHitPerAct[pCurrentPlay]++;

    }
}
