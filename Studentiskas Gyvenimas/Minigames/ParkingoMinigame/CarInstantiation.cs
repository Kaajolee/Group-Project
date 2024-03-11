using Godot;
using Godot.NativeInterop;
using System;
using System.Diagnostics;

public partial class CarInstantiation : Node2D
{

	// Called when the node enters the scene tree for the first time.
	PackedScene parkedCarScene;
	CustomSignals customSignals;
	Random rnd;

	float spawnLocationX;
    public Vector2 rectSize;

	public bool isGameStopped;
	public override void _Ready()
	{
		parkedCarScene = ResourceLoader.Load<PackedScene>("res://Minigames/ShellFolder(Mykolo)/book.tscn");
		rnd = new Random();
        customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		customSignals.ParkingMinigameEnded += GameStopped;
        rectSize = GetViewport().GetVisibleRect().Size;

		isGameStopped = false;

    }
    void InstantiateCar()
	{
		int randomInt = rnd.Next(2);
        spawnLocationX = characterMovement.spawnDestinationX;
        Vector2 position = new Vector2(spawnLocationX, 0);
        Sprite2D scene = (Sprite2D)parkedCarScene.Instantiate();

        if (randomInt == 0)
		{
			Sprite2D newSpriteCar = ChangeSprite(scene, true);
            scene = newSpriteCar;

        }
		else if(randomInt == 1)
		{
            Sprite2D newSpriteCar = ChangeSprite(scene, false);
            scene = newSpriteCar;
        }
        scene.Position = position;
        AddChild(scene);

    }
    void OnTimerTimeout()
    {
		if (isGameStopped == false)
			InstantiateCar();

    }
	Sprite2D ChangeSprite(Sprite2D currentSprite, bool isACar)
	{
		Sprite2D sprite2D = currentSprite;
		if (isACar == true)
		{
            Color randomColor = new Color(
			(float)GD.Randf(),
			(float)GD.Randf(),
            (float)GD.Randf()
            );

			sprite2D.Modulate = randomColor;
        }
		else if(isACar == false)
		{
			sprite2D.Visible = false;
		}
		return sprite2D;
	}
	void GameStopped()
	{
		isGameStopped = true;

    }
}
