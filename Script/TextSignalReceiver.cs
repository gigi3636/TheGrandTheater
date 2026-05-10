using Godot;
using System;

public partial class TextSignalReceiver : Node
{
    [Export] TextBubble textBubbleRef;

    private PlayScreen currentPlayScreenRef;

    public override void _Ready()
    {
        textBubbleRef.OnDialogueFinish += HandleDialogueFinish;
    }

    public void ChangePlayScreen(PlayScreen pNewCurrentPlayScreen)
    {
        if (currentPlayScreenRef != null)
        {
            currentPlayScreenRef.OnDialogueRequested -= LoadTextBubble;
        }

        currentPlayScreenRef = pNewCurrentPlayScreen;
        currentPlayScreenRef.OnDialogueRequested += LoadTextBubble;
    }

    public void LoadTextBubble(string pDialogueKey)
    {
        textBubbleRef.StartMonologue(pDialogueKey);
    }

    private void HandleDialogueFinish(string pDialogueKey)
    {
        if (currentPlayScreenRef != null)
        {
            currentPlayScreenRef.DialogueHasEnded();
        }
    }
}