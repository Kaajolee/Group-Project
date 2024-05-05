using Godot;
using System;
using System.Diagnostics;

public partial class playerCarInstantiation : Node2D
{

	[Export]
	public float parkTweenSpeed, parkTeenDuration;

	[Export]
	public float spawnTweenSpeed, spawnTeenDuration;

<<<<<<< HEAD

	[Export]
	float playerSpawnOffset;
	float fallSpeed;
	float axisYOffest = 200;
=======
    [Export]
    float playerSpawnOffset;
    float fallSpeed;
    float axisYOffest = 80; //250 andriui ok, man 80
>>>>>>> faec7cdae8012cb2250649d2d664cc56a9841296

	public static float spawnDestinationX;

	Vector2 tweenDestination;
	Vector2 rectSize;
	Vector2 playerSpawnLocation;
	CustomSignals customSignals;
	Tween tween;

	PackedScene playerCarScene;
	Area2D currentCar;



<<<<<<< HEAD
	public override void _Ready()
	{
		rectSize = GetWindow().Size;
		float startX = rectSize.X / 1.5f;
		spawnDestinationX = startX;
		tweenDestination = new Vector2(startX, Position.Y);
		Console.WriteLine(tweenDestination);
=======
    public override void _Ready()
    {

        //GetViewportRect();
        rectSize = GetViewportRect().Size;
        float startX = rectSize.X / 1.5f;
        spawnDestinationX = startX;
        tweenDestination = new Vector2(startX, Position.Y);
        Console.WriteLine(tweenDestination);
>>>>>>> faec7cdae8012cb2250649d2d664cc56a9841296

		customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		customSignals.ParkingMinigameEnded += GameStoped;
		customSignals.ParkingMinigamePoint += PointEarned;
		customSignals.ParkingMinigameBottomLine += OnBottomReached;

<<<<<<< HEAD
		playerSpawnLocation = new Vector2(GetWindow().Size.X / 2, GetWindow().Size.Y);
		Position = playerSpawnLocation;
=======
        playerSpawnLocation = new Vector2(rectSize.X / 2, rectSize.Y);
        Position = playerSpawnLocation;
>>>>>>> faec7cdae8012cb2250649d2d664cc56a9841296

		playerCarScene = ResourceLoader.Load<PackedScene>("res://Minigames/ParkingoMinigame/playerCar.tscn");
		currentCar = (Area2D)playerCarScene.Instantiate();
		AddChild(currentCar);

		MovePlayerCarUpwards();

	}
	public override void _ExitTree()
	{
		customSignals.ParkingMinigameEnded -= GameStoped;
		customSignals.ParkingMinigamePoint -= PointEarned;
		customSignals.ParkingMinigameBottomLine -= OnBottomReached;
	}
	public override void _PhysicsProcess(double delta)
	{

<<<<<<< HEAD
	}
	public override void _Process(double delta)
	{
		fallSpeed = objectFallScript.fallSpeed;
		if (Input.IsActionJustPressed("space"))
		{
			MovePlayerCar();
			//InstantiatePlayerCar();
			Debug.WriteLine("space pressed");
		}
		if (Position.Y >= rectSize.Y + 85)
		{
			customSignals.EmitSignal(nameof(CustomSignals.ParkingMinigameBottomLine));
		}
	}
	void MovePlayerCar()
	{
		tween = CreateTween();
		tween.TweenProperty(this, "position:x", tweenDestination.X, parkTweenSpeed);
		
=======
    }
    public override void _Process(double delta)
    {
        fallSpeed = objectFallScript.fallSpeed;
        if (Input.IsActionJustPressed("space"))
        {
            MovePlayerCar();
            //InstantiatePlayerCar();
            Debug.WriteLine("space pressed");
        }
        if (Position.Y >= rectSize.Y)
        {
            customSignals.EmitSignal(nameof(CustomSignals.ParkingMinigameBottomLine));
        }
    }
    void MovePlayerCar()
    {
        tween = CreateTween();
        tween.TweenProperty(this, "position:x", tweenDestination.X, parkTweenSpeed);
        
>>>>>>> faec7cdae8012cb2250649d2d664cc56a9841296

	}
	void GameStoped()
	{
		tween.Stop();
	}
	void PointEarned()
	{
		tween = CreateTween();
		tween.TweenProperty(this, "position:y", rectSize.Y + axisYOffest, 4.1f / fallSpeed + 0.12);

	}
	void InstantiatePlayerCar()
	{
		currentCar = (Area2D)playerCarScene.Instantiate();
		currentCar.Position = Position;
	}
	void MovePlayerCarUpwards()
	{
		tween = CreateTween();
		tween.TweenProperty(this, "position:y", rectSize.Y - 280, spawnTweenSpeed);
	}
	void OnBottomReached()
	{
		Position = playerSpawnLocation;
		MovePlayerCarUpwards();
	}
}
