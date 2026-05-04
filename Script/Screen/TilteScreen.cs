using Godot;
using System;

public partial class TilteScreen : Screen
{
	

	public void _on_play_button_pressed()
	{
		screenManagerRef.SwitchScreen(ScreenManager.SceneEnum.GameScreen);
		CloseScene();
	}
}
