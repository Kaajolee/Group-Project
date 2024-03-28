using Godot;
using System;
using System.Diagnostics;

public partial class playerCarInstantiation : Node2D
{

    [Export]
    public float tweenSpeed;

    [Export]
    private float duration;

    float fallSpeed;
    float axisYOffest = 85;

    public static float spawnDestinationX;

    Vector2 tweenDestination;
    Vector2 rectSize;

    CustomSignals customSignals;
    Tween tween;
    PackedScene playerCarScene;
    Area2D currentCar;
    public override void _Ready()
    {
        rectSize = GetWindow().Size;
        float startX = rectSize.X/ 1.5f;
        spawnDestinationX = startX;
        tweenDestination = new Vector2(startX, Position.Y);
        Debug.WriteLine(tweenDestination);

        customSignals = GetNode<CustomSignals>("/root/CustomSignals");
        customSignals.ParkingMinigameEnded += GameStoped;
        customSignals.ParkingMinigamePoint += PointEarned;

        playerCarScene = ResourceLoader.Load<PackedScene>("res://Minigames/ParkingoMinigame/playerCar.tscn");
        currentCar = (Area2D)playerCarScene.Instantiate();
        currentCar.Position = Position;
        //InstantiatePlayerCar();

    }
    public override void _PhysicsProcess(double delta)
    {

    }
    public override void _Process(double delta)
    {
        fallSpeed = objectFallScript.fallSpeed;
        if (Input.IsActionJustPressed("space"))
        {
             MovePlayerCar(currentCar);
             InstantiatePlayerCar();
        }
    }
    void MovePlayerCar(Area2D currentCar)
    {
        tween = CreateTween();
        tween.TweenProperty(currentCar, "position:x", tweenDestination.X, tweenSpeed);
        

    }
    void GameStoped()
    {
        tween.Stop();
    }
    void PointEarned()
    {
        tween = CreateTween();
        tween.TweenProperty(this, "position:y", rectSize.Y + axisYOffest, 4.1f/fallSpeed);

    }
    void InstantiatePlayerCar()
    {
        currentCar = (Area2D)playerCarScene.Instantiate();
        currentCar.Position = Position;
    }
}
