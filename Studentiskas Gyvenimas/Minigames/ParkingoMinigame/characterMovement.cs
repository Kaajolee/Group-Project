using Godot;
using System;
using System.Diagnostics;

public partial class characterMovement : Area2D
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

    }
    public override void _PhysicsProcess(double delta)
    {

    }
    public override void _Process(double delta)
    {
        fallSpeed = objectFallScript.fallSpeed;
        if (Input.IsActionJustPressed("space"))
        {
             MoveCharacterCar();
        }
    }
    void MoveCharacterCar()
    {
        tween = CreateTween();
        tween.TweenProperty(this, "position:x", tweenDestination.X, tweenSpeed);
        

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
}
