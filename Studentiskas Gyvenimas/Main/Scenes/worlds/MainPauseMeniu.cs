using Godot;
using System;
using System.Diagnostics;

public partial class MainPauseMeniu : Panel
{
	// Called when the node enters the scene tree for the first time.
	CanvasLayer canvasLayer;
	Panel optionsPanel;
	public override void _Ready()
	{
		canvasLayer = GetNode<CanvasLayer>("..");
		optionsPanel = GetNode<Panel>("../OptionsPanel");
		canvasLayer.Visible = false;
		optionsPanel.Visible = false;

	}
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("escape") && @event.IsEcho() == false)
		{
			Debug.WriteLine("escape pressed");

			ToggleWindow();
		}
	}
	void ToggleWindow()
	{
		canvasLayer.Visible = !canvasLayer.Visible;
		GetTree().Paused = !GetTree().Paused;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
	public void Resume()
	{
		Debug.WriteLine("Game Unpaused");
		GetTree().Paused = !GetTree().Paused;
		canvasLayer.Visible = false;

	}
	void Options()
	{
		Debug.WriteLine("Options button pressed");
		optionsPanel.Visible = !optionsPanel.Visible;
	}
	void SaveGame()
	{
		Debug.WriteLine("Save game button pressed");
	}
	void LoadGame()
	{
		Debug.WriteLine("Load game button pressed");
	}
	void Exit()
	{
		Debug.WriteLine("Exit button pressed");
		PackedScene mainMenu = ResourceLoader.Load<PackedScene>("res://Main/Scenes/main/main.tscn");
        GetTree().Paused = !GetTree().Paused;
        GetTree().ChangeSceneToPacked(mainMenu);
		//GetTree().Quit();
	}
}
