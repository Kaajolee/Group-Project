using Godot;
using System;

public partial class scoreUpdate : Label
{
	// Called when the node enters the scene tree for the first time.
	Global global;
	public override void _Ready()
	{
		global = GetNode<Global>("/root/Global");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		UpdateLabelText();
	}
	void UpdateLabelText()
	{
		Text = "Score: " + global.parkingScore;
	}
}
