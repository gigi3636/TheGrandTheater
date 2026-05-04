using Godot;
using System;

public partial class Act1LevelTimer : Node
{
	[Export] private float act1Duration = 120f;
    [Export] private ActProgressionDataRes actProgressionDataRes;

	private const int INTERVAL_DURATION = 4;
    private float nextInterval;
	private Timer currentActProgressionTimer;
    [Signal] public delegate void Act1FinishedEventHandler();

    public override void _Ready()
	{
		currentActProgressionTimer = new Timer();
        currentActProgressionTimer.WaitTime = act1Duration;
		AddChild(currentActProgressionTimer);
		currentActProgressionTimer.Start();
		currentActProgressionTimer.Timeout += OnTimerTimeOut;

        nextInterval = act1Duration - INTERVAL_DURATION;

    }
    public override void _Process(double delta)
    {
        // Every 10s increase the scrolling parallax speed
        if (currentActProgressionTimer.TimeLeft <= nextInterval)
        {
            actProgressionDataRes.IncreaseSpeed();
            nextInterval -= INTERVAL_DURATION;
        }
    }
    private void OnTimerTimeOut()
	{
		// End this act a the end of the timer
        EmitSignal(SignalName.Act1Finished);
    }
}
