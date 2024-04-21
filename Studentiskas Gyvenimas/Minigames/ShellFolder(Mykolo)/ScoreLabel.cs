using Godot;
using System;

public partial class ScoreLabel : Label
{
	public int Score { get; set; }
	// Called when the node enters the scene tree for the first time.
	CustomSignals customSignals;
	Global global;
	public override void _Ready()
	{
        customSignals = GetNode<CustomSignals>("/root/CustomSignals");
        global = GetNode<Global>("/root/Global");
        customSignals.BookMinigamePoint += () => scorePoint();
        customSignals.BookMinigamePointDeduct += () => scoreDeduct();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	void scorePoint() 
	{ 
		Score++;
		global.bookScore += global.bookScore;
		Text = $"Score: " + Score;
	}

	void scoreDeduct()
	{
		if(Score > 0)
		{
            global.bookScore -= global.bookScore;
            Score--;
		}
        Text = $"Score: " + Score;
    }
}
