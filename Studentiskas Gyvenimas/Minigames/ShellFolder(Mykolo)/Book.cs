using Godot;
using System;

public partial class Book : CharacterBody2D
{
	private float Speed = 2.5f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        //this.ContactMonitor = true;
        //this.MaxContactsReported = 1;
		
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var collision = MoveAndCollide(Vector2.Down * Speed);
		if (collision != null) 
		{
			if (collision.GetCollider() is Player)
			{
                GD.Print("HIT");
            }
			QueueFree();
		}
	}
}
