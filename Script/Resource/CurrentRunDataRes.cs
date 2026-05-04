using Godot;
using System;
using System.Collections.Generic;

public partial class CurrentRunDataRes : Resource
{
    public Dictionary<int, int> playerHitPerAct {  get; private set; }

    public void StartNewRun()
    {
        playerHitPerAct = new Dictionary<int, int>();
    }

    public void RegisterNewHit(int pId)
    {
        if (!playerHitPerAct.ContainsKey(pId)) playerHitPerAct.Add(pId, 0);
        playerHitPerAct[pId]++;
        GD.Print(playerHitPerAct[pId]);
    }
}
