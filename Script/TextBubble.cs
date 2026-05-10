using Godot;
using System;

public partial class TextBubble : Control
{
    [Export] private TextShower textShowerRef;
    [Export] private CanvasLayer canvasLayerRef;

    [Export] private float delayBetweenTexts = 1.0f;

    private string currentTextToShowKey;
    private string[] textSliced;
    private int textSlicedId;

    public event Action<string> OnDialogueFinish;
    private Timer autoNextTimer;

    public override void _Ready()
    {
        autoNextTimer = new Timer();
        autoNextTimer.WaitTime = delayBetweenTexts;
        autoNextTimer.OneShot = true; 

        autoNextTimer.Timeout += NextPartToShow;

        AddChild(autoNextTimer);
        Visible = false;
        canvasLayerRef.Visible = false;

    }

    public void Initialize(string pTextToShowKey)
    {
        StartMonologue(pTextToShowKey);
    }

    public void StartMonologue(string pTextToShowKey)
    {
        Visible = true;
        canvasLayerRef.Visible = true;

        currentTextToShowKey = pTextToShowKey;

        string lAllTextToSlice = Tr(currentTextToShowKey);

        textSliced = lAllTextToSlice.Split('|');
        textSlicedId = 0;

        ShowCurrentTextSlice();
    }

    public void NextPartToShow()
    {
        textSlicedId++;

        if (textSlicedId < textSliced.Length)
        {
            ShowCurrentTextSlice();
        }
        else
        {
            EndMonologue();
        }
    }

    private void ShowCurrentTextSlice()
    {
        string textToShow = textSliced[textSlicedId].Trim();
        textShowerRef.ShowText(textToShow);

        autoNextTimer.Start();
    }

    private void EndMonologue()
    {
        textSliced = null;
        textShowerRef.ShowText("");

        autoNextTimer.Stop();
        Visible = false;
        canvasLayerRef.Visible = false;
        OnDialogueFinish?.Invoke(currentTextToShowKey);

    }
}