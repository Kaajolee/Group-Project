using Godot;
using System;
using System.Diagnostics;

public partial class SceneTransitionTrigger : Area2D
{
	// Called when the node enters the scene tree for the first time.
	AnimationPlayer animPlayer;
	public override void _Ready()
	{
		animPlayer = (AnimationPlayer)GetNode("../AnimationPlayer");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
	void OnBodyEntered(Node2D body)
	{
        Debug.WriteLine("Collision entered");
        if (body.IsInGroup("player"))
		{
            Debug.WriteLine("player entered the collision");
            animPlayer.Play("fade_out");
		}
	}
}
