using Godot;
using System;

public partial class TextShower : Node
{
	[Export] private Label textLabel;


    public void ShowText ( string pText)
	{
        textLabel.Text = pText;
    }
}
