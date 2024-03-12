using Godot;
using Godot.NativeInterop;
using System;
using System.Diagnostics;

public partial class CarInstantiation : Node2D
{

	// Called when the node enters the scene tree for the first time.

	[Export]
	public float parkingSpaceOffset;
	public float playerSpawnOffset = 50;
	PackedScene parkedCarScene;
	PackedScene playerScene;
	CustomSignals customSignals;
	Random rnd;

	float spawnLocationX;


	public bool isGameStopped;
	public override void _Ready()
	{
		parkedCarScene = ResourceLoader.Load<PackedScene>("res://Minigames/ParkingoMinigame/parkedCar.tscn");
		playerScene = ResourceLoader.Load<PackedScene>("res://Minigames/ParkingoMinigame/player.tscn");
        rnd = new Random();
        customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		customSignals.ParkingMinigameEnded += CarCrashed;
        customSignals.ParkingMinigamePoint += PointEarned;


        isGameStopped = false;

    }
    void InstantiateCar()
	{
		int randomInt = rnd.Next(2);
        spawnLocationX = characterMovement.spawnDestinationX;
        Vector2 position = new Vector2(spawnLocationX, 0);
        Sprite2D scene = (Sprite2D)parkedCarScene.Instantiate();

		//masina
        if (randomInt == 0)
		{
			Sprite2D newSpriteCar = ChangeSprite(scene, true);
            scene = newSpriteCar;

        }
		//tuscia vieta
		else if(randomInt == 1)
		{
			position += new Vector2(parkingSpaceOffset, 0);
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
	void CarCrashed()
	{
		isGameStopped = true;

    }
	void InstantiatePlayer()
	{
        spawnLocationX = characterMovement.spawnDestinationX;
        Vector2 position = new Vector2(GetWindow().Size.X/2, GetWindow().Size.Y + playerSpawnOffset);
        Area2D playerSceneObj = (Area2D)playerScene.Instantiate();
        playerSceneObj.Position = position;
		AddChild(playerSceneObj);
    }
    void PointEarned()
    {
		InstantiatePlayer();
        //isGameStopped = true;

    }
}
