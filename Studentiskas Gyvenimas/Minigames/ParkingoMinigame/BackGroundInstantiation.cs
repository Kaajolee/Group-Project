using Godot;
using System;
using System.Diagnostics;
using static CustomSignals;

public partial class BackGroundInstantiation : Node2D
{
    PackedScene backgroundScene;
	Vector2 instPos;
    float fallSpeed;
    Vector2 rectSize;
    Vector2 spritePos;
    CustomSignals customSignals;
    public override void _Ready()
	{
        backgroundScene = ResourceLoader.Load<PackedScene>("res://Minigames/ParkingoMinigame/Background.tscn");
        instPos = GetNode<Node2D>("./Node2D").Position;
        customSignals = GetNode<CustomSignals>("/root/CustomSignals");
        rectSize = GetViewportRect().Size;


        Instantiatebackground(new Vector2(rectSize.X /2, 30), backgroundScene);
        Instantiatebackground(instPos, backgroundScene);

        customSignals.ParkingMinigameBackgroundDeleted += () => Instantiatebackground(new Vector2(instPos.X, instPos.Y), backgroundScene);
    }

    public override void _ExitTree()
    {
        customSignals.ParkingMinigameBackgroundDeleted -= () => Instantiatebackground(new Vector2(instPos.X, instPos.Y), backgroundScene);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{

    }
    void Instantiatebackground(Vector2 position, PackedScene spriteScene)
    {
        Sprite2D scene = (Sprite2D)spriteScene.Instantiate();
        scene.Position = position;
        Debug.WriteLine($"BG instantiated at {scene.Position}");
        AddChild(scene);
    }
}
