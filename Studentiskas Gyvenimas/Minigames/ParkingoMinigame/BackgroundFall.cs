using Godot;
using System;
using System.Diagnostics;

public partial class BackgroundFall : Sprite2D
{
    float fallSpeed;
    Vector2 rectSize;
    Vector2 pos;
    CustomSignals customSignals;

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Ready()
    {
        rectSize = GetViewportRect().Size;
        customSignals = GetNode<CustomSignals>("/root/CustomSignals");

    }
    public override void _Process(double delta)
    {
        fallSpeed = objectFallScript.fallSpeed;

        if (Position.Y >= rectSize.Y)
        {
            Debug.WriteLine($"BG deleted at {Position}");
            customSignals.EmitSignal(nameof(CustomSignals.ParkingMinigameBackgroundDeleted));
            QueueFree();

        }
        pos = Position;
        pos.Y += fallSpeed;
        Position = pos;
    }
}
