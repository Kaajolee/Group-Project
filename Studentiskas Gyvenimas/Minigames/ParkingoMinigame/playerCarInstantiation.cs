using Godot;
using System;
using System.Diagnostics;

public partial class playerCarInstantiation : Node2D
{

    [Export]
    public float parkTweenSpeed, parkTeenDuration;

    [Export]
    public float spawnTweenSpeed, spawnTeenDuration;


    [Export]
    float playerSpawnOffset;
    float fallSpeed;
    float axisYOffest = 100;

    public static float spawnDestinationX;

    bool carParked = false;

    Vector2 tweenDestination;
    Vector2 rectSize;
    Vector2 playerSpawnLocation;
    Vector2 playerCarFallVector;
    CustomSignals customSignals;
    Tween tween;

    PackedScene playerCarScene;
    Area2D currentCar;



    public override void _Ready()
    {
        rectSize = GetViewportRect().Size;
        float startX = rectSize.X / 1.5f;
        spawnDestinationX = startX;
        tweenDestination = new Vector2(startX, Position.Y);
        Console.WriteLine(tweenDestination);

        customSignals = GetNode<CustomSignals>("/root/CustomSignals");
        customSignals.ParkingMinigameEnded += GameStoped;
        customSignals.ParkingMinigamePoint += PointEarned;
        customSignals.ParkingMinigameBottomLine += OnBottomReached;

        playerSpawnLocation = new Vector2(rectSize.X / 2, rectSize.Y);
        Position = playerSpawnLocation;

        playerCarScene = ResourceLoader.Load<PackedScene>("res://Minigames/ParkingoMinigame/playerCar.tscn");
        currentCar = (Area2D)playerCarScene.Instantiate();
        AddChild(currentCar);

        Debug.WriteLine($"Players start pos: {playerSpawnLocation}");
        Debug.WriteLine($"ViewPortRect size: {rectSize}");
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

        if (carParked)
        {
            playerCarFallVector = Position;
            playerCarFallVector.Y += fallSpeed;
            Position = playerCarFallVector;
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
        

    }
    void GameStoped()
    {
        tween.Stop();
    }
    void PointEarned()
    {
        carParked = true;
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
        carParked = false;
        MovePlayerCarUpwards();
    }
}
