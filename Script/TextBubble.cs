using Godot;
using System;
using System.Collections.Generic;

public partial class TextBubble : Control
{
	[Export] private TextShower textShowerRef;
    [Export(PropertyHint.File, "*.txt")] private string _cheminFichierTexte;

    private Dictionary<string, string> allText;

    public override void _Ready()
    {
        allText = TextParser.ChargerDictionnaireDepuisTxt(_cheminFichierTexte);
    }

    public void RightText(string pTextToShowKey)
	{
        if (!allText.ContainsKey(pTextToShowKey)) return;

        textShowerRef.ShowText(allText[pTextToShowKey]);
    }
}
