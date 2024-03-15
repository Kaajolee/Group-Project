using Godot;
using System;

public partial class CustomSignals : Node
{
    [Signal]
    public delegate void TyperMinigameEndedEventHandler();

    [Signal]
    public delegate void ParkingMinigameEndedEventHandler();

    [Signal]
    public delegate void ParkingMinigamePointEventHandler();

    [Signal]
    public delegate void CockroachMinigameEndedEventHandler();

    [Signal]
    public delegate void BookMinigamePointEventHandler();

}
