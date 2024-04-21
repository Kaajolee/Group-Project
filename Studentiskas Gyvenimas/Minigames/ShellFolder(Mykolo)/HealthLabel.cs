using Godot;
using System;

public partial class HealthLabel : Label
{
	public int health = 3;
	CustomSignals customSignals;
	PackedScene gameOver;
	Label scoreLabel;
	Global global;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		gameOver = ResourceLoader.Load<PackedScene>("res://Minigames/ShellFolder(Mykolo)/GameOver.tscn");
        global = GetNode<Global>("/root/Global");
        //scoreLabel = GetNode<Label>("UI/ScoreLabel");
        //GD.Print(scoreLabel.ToString());
        customSignals.BookMinigamePointDeduct += () => loseHealth();
		customSignals.BookMinigameEnded += () => gameEnd();
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

	void gameEnd()
	{
		InstantiateWindow();
		
	}

	void InstantiateWindow()
	{
		Node2D gameover = (Node2D)gameOver.Instantiate();
		gameover.Position = GetViewport().GetVisibleRect().Size / 2;
        Label label = gameover.GetNode<Label>("CanvasLayer/Panel/Label");
        label.Text = string.Format("Score: " + global.bookScore);
        AddChild(gameover);
    }


}
