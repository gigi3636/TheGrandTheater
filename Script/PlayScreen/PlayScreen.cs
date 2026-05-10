using Godot;
using System;

public partial class PlayScreen : Control
{
    [Signal] public delegate void OnPlayFinishedEventHandler();

    public event Action<string> OnDialogueRequested;



	public void StartNewDialogue(string pDialogueKey)
	{
        OnDialogueRequested?.Invoke(pDialogueKey);
    }

	public virtual void StartPlay()
	{

	}

    public virtual void DialogueHasEnded()
    {
    }
}
