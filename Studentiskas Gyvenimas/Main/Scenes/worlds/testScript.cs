using Godot;
using System;

public partial class testScript : RigidBody2D
{
    // Called when the node enters the scene tree for the first time.
    [Export]
    public float Speed = 5;
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        Vector2 direction = Vector2.Zero;
        if (Input.IsActionPressed("ui_right"))
            direction.X += 1;
        if (Input.IsActionPressed("ui_left"))
            direction.X -= 1;
        if (Input.IsActionPressed("ui_down"))
            direction.Y += 1;
        if (Input.IsActionPressed("ui_up"))
            direction.Y -= 1;

        direction = direction.Normalized();
        
        MoveAndCollide(direction * Speed);
    }
}
