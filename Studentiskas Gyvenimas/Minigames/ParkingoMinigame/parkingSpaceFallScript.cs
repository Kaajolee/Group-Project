using Godot;
using System;
using System.Diagnostics;

public partial class parkingSpaceFallScript : Sprite2D
{
    // Called when the node enters the scene tree for the first time.
    [Export]
    public float speed;
    private float screenBottomY;

    public static float fallSpeed;

    CustomSignals customSignals;

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Ready()
    {
        customSignals = GetNode<CustomSignals>("/root/CustomSignals");
        screenBottomY = GetViewport().GetVisibleRect().Size.Y;
        customSignals.ParkingMinigameEnded += StopParkingSpace;
    }
    public override void _Process(double delta)
	{
        screenBottomY = GetViewport().GetVisibleRect().Size.Y + 100;

        var position = Position;
        var deltaY = speed * (float)delta * 50;
        fallSpeed = deltaY;
        Console.WriteLine(fallSpeed);
        position.Y += deltaY;
        Position = position;

        if (Position.Y >= screenBottomY)
            QueueFree();

    }
    void StopParkingSpace()
    {
        speed = 0;
    }
}
