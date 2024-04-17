using Godot;
using System;
using System.Diagnostics;

public partial class PauseMeniuScript : Control
{
	// Called when the node enters the scene tree for the first time.
	CanvasLayer layer;
    bool isPaused;
	public override void _Ready()
	{
        layer = GetNode<CanvasLayer>("./CanvasLayer");
        layer.Visible = false;
        isPaused = false;
        //Hide();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

    }
    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("escape") && @event.IsEcho() == false)
        {
            //Debug.WriteLine("escape pressed");

            ToggleWindow();
        }
    }
	void ToggleWindow()
	{
        layer.Visible = !layer.Visible;
        Debug.WriteLine("Game paused");
        GetTree().Paused = !GetTree().Paused;
    }
    void Pause()
    {
        layer.Visible = true;
        GetTree().Paused = !GetTree().Paused;
    }
    void UnPause()
    {
        if(isPaused == true)
        {
            isPaused = false;
            layer.Visible = false;
            GetTree().Paused = !GetTree().Paused;
        }

    }
}
