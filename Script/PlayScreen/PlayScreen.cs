using Godot;
using System;

public partial class PlayScreen : Control
{
	[Export] protected PlayerController playerControllerRef;
	protected IPlayerAction playerAction;
    [Signal] public delegate void OnPlayFinishedEventHandler();

    public event Action<string> OnDialogueRequested;

    public override void _Ready()
	{
		playerControllerRef.ChangePlayerAction(ReturnPlayerAction());
    }

	protected virtual IPlayerAction ReturnPlayerAction()
	{
		return null;
	}

	public void StartNewDialogue(string pDialogueKey)
	{
		GD.Print("sat");
        OnDialogueRequested?.Invoke(pDialogueKey);
    }

	public virtual void StartPlay()
	{

	}
}
