using Godot;
using System;
using System.Diagnostics;

public partial class PauseMeniuScript : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
    public override void _Input(InputEvent @event)
    {
		if (@event.IsActionPressed("escape") && @event.IsEcho() == false)
		{
			ToggleWindow();
		}
    }
	void ToggleWindow()
	{
		Visible = !Visible;
		Debug.WriteLine("method acessed");
	}
}
