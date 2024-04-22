using Godot;
using System;

public partial class PrimaryMenuInstantiation : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	PackedScene pauseMenu;
	CanvasLayer menuNode;

	public override void _Ready()
	{
		pauseMenu = ResourceLoader.Load<PackedScene>("res://Main/Scenes/worlds/MainPauseMeniu.tscn");
		menuNode = (CanvasLayer)pauseMenu.Instantiate();
		AddChild(menuNode);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
