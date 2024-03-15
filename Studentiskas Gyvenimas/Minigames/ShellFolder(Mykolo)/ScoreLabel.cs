using Godot;
using System;

public partial class ScoreLabel : Label
{
	public int Score { get; set; }
	// Called when the node enters the scene tree for the first time.
	CustomSignals customSignals;
	public override void _Ready()
	{
        customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		customSignals.BookMinigamePoint += () => scorePoint();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	void scorePoint() 
	{ 
		Score++; 
		Text = $"Score: " + Score;
	}
}
