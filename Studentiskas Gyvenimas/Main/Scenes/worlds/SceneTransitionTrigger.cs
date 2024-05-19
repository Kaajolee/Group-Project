using Godot;
using System;
using System.Diagnostics;

public partial class SceneTransitionTrigger : Area2D
{
	// Called when the node enters the scene tree for the first time.
	AnimationPlayer animPlayer;
	public override void _Ready()
	{
		animPlayer = (AnimationPlayer)GetNode("./AnimationPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
	void OnBodyEntered(Node2D body)
	{
		Debug.WriteLine(body.ToString());
		if (body.IsInGroup("player"))
		{
			
			Debug.WriteLine("player entered the collision");
			animPlayer.Play("fade_out");
		}
	}
	void OnAnimationPlayerAnimationFinished(string anim_name)
	{
		//Debug.WriteLine(nameLength);
		PackedScene requiredScene = new PackedScene();

		switch (Name)
		{
			case "TyperMinigameTrigger":
				requiredScene = ResourceLoader.Load<PackedScene>("res://Minigames/GreitoRasymoMinigame/ButtonSmasher.tscn");
				break;
			case "ParkingMinigameTrigger":
				requiredScene = ResourceLoader.Load<PackedScene>("res://Minigames/ParkingoMinigame/ParkTheCar.tscn");
				break;
			case "CockroachMinigameTrigger":
				requiredScene = ResourceLoader.Load<PackedScene>("res://Minigames/TarakonuMinigame/HitTheBug.tscn");
				break;
			case "BookMinigameTrigger":
				requiredScene = ResourceLoader.Load<PackedScene>("res://Minigames/ShellFolder(Mykolo)/world.tscn");
				break;

		}
		if (requiredScene != null)
		{
			GetTree().ChangeSceneToPacked(requiredScene);
		}
		else
			Debug.Fail("Ivyko klaida uzkraunant scena" + Name);
	}
	
}
