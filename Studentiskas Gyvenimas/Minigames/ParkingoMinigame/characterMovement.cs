using Godot;
using System;
using System.Diagnostics;

public partial class characterMovement : Area2D
{
    // Called when the node enters the scene tree for the first time.
    [Export]
    public int Speed { get; set; } = 400;
    [Export]
    public float tweenSpeed;
    private float currentTime;
    [Export]
    private float duration;

    public static float spawnDestinationX;
    Vector2 tweenDestination;

    
    public override void _Ready()
    {
        Vector2 rectSize = GetWindow().Size;
        float startX = rectSize.X / 1.5f;
        spawnDestinationX = startX;
        tweenDestination = new Vector2(startX, Position.Y);
        //tweenDestination = instaScript.spawnLocation;

        Debug.WriteLine(tweenDestination);

    }
    public override void _PhysicsProcess(double delta)
    {
        //ReadInput();
        //MoveAndSlide();
    }
    public override void _Process(double delta)
    {

        if (Input.IsActionJustPressed("space"))
        {
            MoveCharacterCar(delta);
        }
    }
    void MoveCharacterCar(double delta)
    {
        currentTime += (float)delta;

        if (currentTime < duration)
        {
            // Use Mathf.Lerp to interpolate between startValue and endValue
            float t = currentTime / duration;
            float interX = Mathf.Lerp(Position.X, spawnDestinationX, t);
            Vector2 vector2 = new Vector2(interX, Position.Y);
            Position = vector2;
        }
        //Tween tween = CreateTween();
        //Debug.WriteLine(tweenDestination);
        //tween.TweenProperty(GetNode("Player"), "position", tweenDestination, tweenSpeed);
        //Debug.WriteLine("test");
        // tween.SetTrans(Tween.TransitionType.Elastic);

    }
}
