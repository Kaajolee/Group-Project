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
	Global global;
	CustomSignals customSignals;
	
	public override void _Ready()
	{
        sprite = GetNode<Sprite2D>(".");
        screenBottomY = GetViewportRect().Size.Y;

        customSignals = GetNode<CustomSignals>("/root/CustomSignals");
        global = GetNode<Global>("/root/Global");
        customSignals.ParkingMinigameEnded += StopCar;
        customSignals.ParkingMinigamePoint += StopCar;
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
			if(Visible == false)
			{
				customSignals.EmitSignal(nameof(CustomSignals.ParkingMinigamePoint));
				global.parkingScore += 1;
				global.CurrentScore();
                Debug.WriteLine("Point earned");
			}
			else
            customSignals.EmitSignal(nameof(CustomSignals.ParkingMinigameEnded));
        }

	}
}
