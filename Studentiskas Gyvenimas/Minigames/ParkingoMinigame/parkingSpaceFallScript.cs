using Godot;
using System;

public partial class parkingSpaceFallScript : Sprite2D
{
    // Called when the node enters the scene tree for the first time.
    [Export]
    public float speed;
    private float screenBottomY;

    public static float fallSpeed;

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Ready()
    {
        screenBottomY = GetViewport().GetVisibleRect().Size.Y;

    }
    public override void _Process(double delta)
	{
        screenBottomY = GetViewport().GetVisibleRect().Size.Y;

        var position = Position;
        var deltaY = speed * (float)delta * 50;
        fallSpeed = deltaY;
        Console.WriteLine(fallSpeed);
        position.Y += deltaY;
        Position = position;

        if (Position.Y >= screenBottomY)
            QueueFree();

    }
}
