using Godot;
using System;

public partial class Book : CharacterBody2D
{
	//public float Speed = 2.5f;
    public float Speed = GD.RandRange(2,5) + GD.Randf();

    CustomSignals customSignals;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//this.ContactMonitor = true;
		//this.MaxContactsReported = 1;
		customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		//customSignals.BookMinigamePoint += 
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var collision = MoveAndCollide(Vector2.Down * Speed);
		if (collision != null) 
		{
			if (collision.GetCollider() is Player)
			{
				GD.Print("HIT" + Speed);
				//EmitSignal(nameof(customSignals.BookMinigamePoint));
				customSignals.EmitSignal(nameof(customSignals.BookMinigamePoint));
			}
			else if (collision.GetCollider() is StaticBody2D) 
			{
				GD.Print("YIKES");
                customSignals.EmitSignal(nameof(customSignals.BookMinigamePointDeduct));
            }
			QueueFree();
		}
	}
}
