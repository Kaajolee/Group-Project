using Godot;
using Godot.NativeInterop;
using System;
using System.Diagnostics;

public partial class CarInstantiation : Node2D
{

	// Called when the node enters the scene tree for the first time.
	PackedScene parkedCarScene;
	Random rnd;
	[Export]
	public Vector2 spawnLocation; 
	public override void _Ready()
	{
		parkedCarScene = ResourceLoader.Load<PackedScene>("res://parkedCar.tscn");
		rnd = new Random();

        Vector2 rectSize = GetViewport().GetVisibleRect().Size;

       // carSpawnPosX = windowX / 1.2f;

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		/*if (Input.IsActionJustPressed("space"))
		{
			InstantiateObject();
		}*/
	}

    void InstantiateCar()
	{
		Vector2 position = PositionGenerator(); 
		Node2D scene = (Sprite2D)parkedCarScene.Instantiate();
		scene.Position = position;
        AddChild(scene);

        //Debug.WriteLine("Object instantiated | pos : " + position.ToString());
    }
	Vector2 PositionGenerator()
	{
		Vector2 rectSize = GetViewport().GetVisibleRect().Size;
        //Debug.WriteLine("Screen size: " + rectSize);
        //float windowY = rectSize.Y;
        Vector2 pos = spawnLocation;
		//carSpawnPos.X = windowX / 1.5f;
        //Debug.WriteLine(pos);
        return pos;

	}
    void OnTimerTimeout()
    {
		if (rnd.Next(2) == 1)
		{
			InstantiateCar();
		}
		else
			return;
		
		
    }



}
