using Godot;
using System;
using System.Diagnostics;

public partial class GameEndedExitButtonPressed : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		Pressed += ExitGameWhenCompleted;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
    void ExitGameWhenCompleted()
    {
        Debug.WriteLine("exit game when completed button pressed");
        PackedScene mainWorld = ResourceLoader.Load<PackedScene>("res://Main/Scenes/worlds/world.tscn");
        GetTree().ChangeSceneToPacked(mainWorld);
    }
}
