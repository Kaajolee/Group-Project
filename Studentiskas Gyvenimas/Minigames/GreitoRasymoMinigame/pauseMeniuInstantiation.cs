using Godot;
using System;

public partial class pauseMeniuInstantiation : Node2D
{
    PackedScene pauseMenu;
    AnimationPlayer animPlayer;
    Control menuNode;

    public override void _Ready()
	{
        pauseMenu = ResourceLoader.Load<PackedScene>("res://Minigames/TarakonuMinigame/PauseMeniuInGame.tscn");
        menuNode = (Control)pauseMenu.Instantiate();
        AddChild(menuNode);
        menuNode.Visible = false;

        animPlayer = GetNode<AnimationPlayer>("./CanvasLayer/AnimationPlayer");
        animPlayer.Play("fade_in");
    }


	public override void _Process(double delta)
	{
	}
}
