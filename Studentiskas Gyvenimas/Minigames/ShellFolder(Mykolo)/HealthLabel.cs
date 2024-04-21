using Godot;
using System;

public partial class HealthLabel : Label
{
	public int health = 3;
	CustomSignals customSignals;
	//PackedScene gameOver;
	Label scoreLabel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		//scoreLabel = GetNode<Label>("UI/ScoreLabel");
		//GD.Print(scoreLabel.ToString());
        customSignals.BookMinigamePointDeduct += () => loseHealth();
		customSignals.BookMinigameEnded += () => GD.Print("BAIGESI");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	void loseHealth()
	{
		Text = "";
		health -= 1;
		if (health == 0) 
		{
			customSignals.EmitSignal(nameof(customSignals.BookMinigameEnded));
		}
		for (int i = 0; i < health; i++) 
		{ 
			Text += $"❤";
		}
	}
	/*
	void InstantiateWindow()
	{
		Node2D gameover = (Node2D)gameOver.Instantiate();
		gameover.Position = GetViewport().GetVisibleRect().Size / 2;
        Label label = gameover.GetNode<Label>("CanvasLayer/Panel/Label");
        label.Text = string.Format("lmao");
        AddChild(gameover);
    }*/
}
