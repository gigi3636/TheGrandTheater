using Godot;
using System;

public partial class TextSignalReceiver : Node
{
	[Export] TextBubble textBubbleRef;

	private PlayScreen currentPlayScreenRef;

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
        GD.Print("text receive");
        textBubbleRef.StartMonologue(pDialogueKey);
    }
}
