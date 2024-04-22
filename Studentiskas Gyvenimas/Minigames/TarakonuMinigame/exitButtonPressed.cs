using Godot;
using System;
using System.Diagnostics;

public partial class exitButtonPressed : Button
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Pressed += DoSomething;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
    void DoSomething()
    {
        Debug.WriteLine("Exit button pressed");
        PackedScene main = ResourceLoader.Load<PackedScene>("res://Main/Scenes/worlds/world.tscn");
        GetTree().Paused = false;
        GetTree().ChangeSceneToPacked(main);
    }
    void ExitGameWhenCompleted()
    {
        Debug.WriteLine("exit game when completed button pressed");
    }
}
