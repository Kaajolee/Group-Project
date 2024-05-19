using Godot;
using Godot.Collections;
using System;
using System.Diagnostics;

public partial class CarInstantiation : Node2D
{

	// Called when the node enters the scene tree for the first time.

	[Export]
	public float parkingSpaceOffset;
	public float playerSpawnOffset = 50;
	public int totalScore;

	PackedScene parkedCarScene;
	PackedScene parkingSpaceScene;
	PackedScene pauseMenu;

	CustomSignals customSignals;

	Texture2D parkingSpaceTexture;
	Random rnd;
	Label label;
	Control menuNode;
	AnimationPlayer animPlayer;
	Global global;

	float spawnLocationX;


	public bool isGameStopped;
	public override void _Ready()
	{
		parkedCarScene = ResourceLoader.Load<PackedScene>("res://Minigames/ParkingoMinigame/parkedCar.tscn");
		parkingSpaceScene = ResourceLoader.Load<PackedScene>("res://Minigames/ParkingoMinigame/parkingSpace.tscn");
		pauseMenu = ResourceLoader.Load<PackedScene>("res://Minigames/TarakonuMinigame/PauseMeniuInGame.tscn");


		animPlayer = GetNode<AnimationPlayer>("./CanvasLayer/AnimationPlayer");
		customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		global = GetNode<Global>("/root/Global");
		animPlayer.Play("fade_in");


		menuNode = (Control)pauseMenu.Instantiate();
		AddChild(menuNode);
		menuNode.Visible = false;

		bg_music.Instance.Play("Song2");

		//totalScore = 0;
		global.parkingScore = 0;


		customSignals.ParkingMinigameEnded += CarCrashed;
		customSignals.ParkingMinigamePoint += PointEarned;

		rnd = new Random();

		isGameStopped = false;

	}
	public override void _ExitTree()
	{
		customSignals.ParkingMinigameEnded -= CarCrashed;
		customSignals.ParkingMinigamePoint -= PointEarned;
	}

	public override void _Process(double delta)
	{

	}
	void InstantiateCar()
	{
		int randomInt = rnd.Next(2);
		spawnLocationX = playerCarInstantiation.spawnDestinationX;
		Vector2 position = new Vector2(spawnLocationX, 0);
		Sprite2D scene = (Sprite2D)parkedCarScene.Instantiate();

		Sprite2D parkingSpace = (Sprite2D)parkingSpaceScene.Instantiate();
		parkingSpace.Position = position;
		AddChild(parkingSpace);

		//masina
		if (randomInt == 0)
		{
			Sprite2D newSpriteCar = ChangeSprite(scene, true);
			scene = newSpriteCar;

		}
		//tuscia vieta
		else if (randomInt == 1)
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
			sprite2D.Modulate = RandomColorGenerator();
		}
		else if (isACar == false)
		{
			sprite2D.Visible = false;

		}
		return sprite2D;
	}
	void CarCrashed()
	{
		isGameStopped = true;
		global.parkingTotalScore += global.parkingScore;


	}
	void InstantiatePlayer()
	{
		spawnLocationX = playerCarInstantiation.spawnDestinationX;
		Vector2 position = new Vector2(GetWindow().Size.X / 2, GetWindow().Size.Y + playerSpawnOffset);
		Debug.WriteLine("Player pos: " + position);
		//Node2D playerSceneObj = (Node2D)playerScene.Instantiate();
		//playerSceneObj.Position = position;
		//AddChild(playerSceneObj);
	}
	void PointEarned()
	{
		//InstantiatePlayer();
		//isGameStopped = true;

	}
	public Color RandomColorGenerator()
	{
		byte r = (byte)rnd.Next(0, 256);
		byte g = (byte)rnd.Next(0, 256);
		byte b = (byte)rnd.Next(0, 256);
		byte a = 255;

		return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
	}

}
