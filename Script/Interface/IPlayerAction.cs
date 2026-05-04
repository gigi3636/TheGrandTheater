using Godot;
using System;

public interface IPlayerAction 
{
    public void OnButtonPressed();
    public void OnButtonReleased();
    public void OnButtonIdle();
    public void Update(float pDelta);
}
