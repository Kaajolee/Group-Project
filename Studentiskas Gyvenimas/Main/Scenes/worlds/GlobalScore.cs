using Godot;
using System;

public partial class GlobalScore : Label
{
	Global global;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		global = GetNode<Global>("/root/Global");
		Text = "Total score: 0";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		UpdateLabelText();
	}
	void UpdateLabelText()
	{
		Text = "Total score: " + global.Sum().ToString();
	}
}
