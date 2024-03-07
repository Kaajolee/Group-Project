using Godot;
using System;
using System.Diagnostics;

public partial class characterMovement : CharacterBody2D
{
    // Called when the node enters the scene tree for the first time.
    [Export]
    public int Speed { get; set; } = 400;
    [Export]
    public float tweenSpeed;
    Vector2 tweenDestination;
    public override void _Ready()
    {
        CarInstantiation instaScript = (CarInstantiation)GetParent().GetNode(".");

        tweenDestination = instaScript.spawnLocation;

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
            //MoveCharacterCar();
            MoveAndCollide(tweenDestination);
        }
    }
    void ReadInput()
    {
        Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
    }
    void MoveCharacterCar()
    {
        Tween tween = CreateTween();
        Debug.WriteLine(tweenDestination);
        tween.TweenProperty(this, "position", tweenDestination, tweenSpeed);
        Debug.WriteLine("test");
       // tween.SetTrans(Tween.TransitionType.Elastic);
        
    }
    void OnPlayerAreaEntered(Area2D area)
    {

    }
    //void OnCollisionEnterTest(Node body)
    //{
    //    if (body.IsInGroup("car"))
    //    {
    //        Debug.WriteLine("player died");

    //    }
    //    else if (body.IsInGroup("point"))
    //    {
    //        Debug.WriteLine("player earned points");
    //    }
    //}
}
