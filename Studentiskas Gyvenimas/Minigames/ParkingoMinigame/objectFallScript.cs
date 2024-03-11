using Godot;
using System;
using System.Diagnostics;

public partial class objectFallScript : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	public float speed;
    private float screenBottomY;

    private Sprite2D sprite;
	private Tween tween;

	CustomSignals customSignals;
	
	public override void _Ready()
	{
        sprite = GetNode<Sprite2D>(".");
        screenBottomY = GetViewportRect().Size.Y;

        customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		customSignals.ParkingMinigameEnded += StopCar;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        screenBottomY = GetViewportRect().Size.Y;

		var position = Position;

        position.Y += speed * (float)delta * 50;
		Position = position;

		if (Position.Y >= screenBottomY)
			QueueFree();

	}
	void StopCar()
	{
		speed = 0;
	}
	void OnCarAreaEntered(Area2D area)
	{
		if (area.IsInGroup("player"))
		{
            customSignals.EmitSignal(nameof(CustomSignals.ParkingMinigameEnded));
        }
	}
}
