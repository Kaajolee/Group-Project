using Godot;
using System;

public partial class CustomSignals : Node
{
    [Signal]
    public delegate void TyperMinigameEndedEventHandler();

    [Signal]
    public delegate void ParkingMinigameEndedEventHandler();
}
