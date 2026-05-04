using Godot;
using System;

public partial class Screen : Control
{
    protected ScreenManager screenManagerRef;

    public void Initialize(ScreenManager pScreenManager)
    {
        screenManagerRef = pScreenManager;
    }

    public virtual void LoadScene()
    {
        Visible = true;
    }

    public virtual void CloseScene()
    {
        Visible = false;
    }
}
