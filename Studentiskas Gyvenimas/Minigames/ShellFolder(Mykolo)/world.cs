using Godot;
using System;

public partial class world : Node2D
{
	public int Score { get; set; }
	PackedScene pauseMenu;
	Control menuNode;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		bg_music.Instance.Play("Song2");
		Score = 0;
		pauseMenu = ResourceLoader.Load<PackedScene>("res://Minigames/TarakonuMinigame/PauseMeniuInGame.tscn");

		menuNode = (Control)pauseMenu.Instantiate();
		AddChild(menuNode);
		menuNode.Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
