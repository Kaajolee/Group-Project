using Godot;
using System;

public partial class ScoreLabel : Label
{
	public int Score { get; set; }
	Global global;
	// Called when the node enters the scene tree for the first time.
	CustomSignals customSignals;
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
    public override void _ExitTree()
    {
        customSignals.BookMinigamePoint -= scorePoint;
        customSignals.BookMinigamePointDeduct -= scoreDeduct;
    }

    void scorePoint() 
	{ 
		Score++;
		global.bookScore++;
		Text = $"Score: " + Score;
	}

	void scoreDeduct()
	{
		if(Score > 0)
		{
			Score--;
			global.bookScore--;
		}
		Text = $"Score: " + Score;
	}
}
