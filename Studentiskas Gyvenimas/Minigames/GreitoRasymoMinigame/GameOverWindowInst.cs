using Godot;
using System;
using System.Diagnostics;

public partial class GameOverWindowInst : CanvasLayer
{
    // Called when the node enters the scene tree for the first time.
    private CustomSignals customSignals;
    private PackedScene gameEndedScene;
    private Global global;
    public override void _Ready()
	{
        global = GetNode<Global>("/root/Global");
        customSignals = GetNode<CustomSignals>("/root/CustomSignals");
        customSignals.TyperMinigameEnded += GameEnded;
        customSignals.ParkingMinigameEnded += GameEnded;
        customSignals.CockroachMinigameEnded += GameEnded;
        gameEndedScene = ResourceLoader.Load<PackedScene>("res://Minigames/GreitoRasymoMinigame/GameEnded.tscn");
    }
    public override void _ExitTree()
    {
        customSignals.TyperMinigameEnded -= GameEnded;
        customSignals.ParkingMinigameEnded -= GameEnded;
        customSignals.CockroachMinigameEnded -= GameEnded;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
    public void GameEnded()
    {
        string sceneName = GetTree().CurrentScene.Name;
        Debug.WriteLine(sceneName);
        int score = 0;
        switch (sceneName)
        {
            case "HitTheBug":
               score = global.cockroachScore;
                break;

            case "ParkTheCar":
                score = global.parkingScore;
                break;

            case "ButtonSmasher":
                score = global.typerScore;
                break;
        }

        InstantiateWindow(gameEndedScene, score);
    }
    void InstantiateWindow(PackedScene scene, int pointAmount)
    {
        Node2D instantiatedScene = (Node2D)scene.Instantiate();
        instantiatedScene.Position = GetViewport().GetVisibleRect().Size / 2;
        Label label = instantiatedScene.GetNode<Label>("CanvasLayer/Panel/Label");
        label.Text = string.Format("Game over\nScore: " + pointAmount.ToString());
        AddChild(instantiatedScene);
    }
}
