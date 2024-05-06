using Godot;
using System;

public partial class GameOver : Node2D
{
	CustomSignals customSignals;
	Label lable;
	Label scoreLabel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//scoreLabel = GetNode<Label>("res://Minigames/ShellFolder(Mykolo)/score_label.tscn");
		//scoreLabel = ResourceLoader.Load<PackedScene>("res://Minigames/ShellFolder(Mykolo)/score_label.tscn");
		//lable = GetNode<Label>("CanvasLayer/Panel/Label");
		customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		//customSignals.BookMinigamePointDeduct += () => updateScore();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	void updateScore()
	{
		lable.Text = scoreLabel.Text;
	}
}
