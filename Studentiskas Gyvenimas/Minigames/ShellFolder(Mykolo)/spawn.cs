using Godot;
using System;
using System.Drawing;

public partial class spawn : Node2D
{
    // Called when the node enters the scene tree for the first time.
    public Timer timer;
    public PackedScene book;
    public Node2D Posit;
    public bool gameEnd = false;
    CustomSignals customSignals;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
        Posit = GetNode<Node2D>("POSITION");
        book = ResourceLoader.Load<PackedScene>("res://Minigames/ShellFolder(Mykolo)/book.tscn");
        customSignals = GetNode<CustomSignals>("/root/CustomSignals");
        timer.Timeout += () => spawnBook();
        customSignals.BookMinigameEnded += () => gameFinish();

    }

    void spawnBook()
    {
        if (gameEnd == false)
        {
            GD.Print("Spawning book");
            var index = (int)GD.RandRange(0, 5);

            Vector2 spawnPosition = (Posit.GetChild(index) as Marker2D).GlobalPosition;

            GD.Print(spawnPosition.ToString());
            CharacterBody2D newBook = (CharacterBody2D)book.Instantiate();
            AddChild(newBook);
            newBook.GlobalPosition = spawnPosition;
        }
    }

    void gameFinish()
    {
        gameEnd = true;
    }
}
