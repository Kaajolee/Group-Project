using Godot;
using System;

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
        gameEndedScene = ResourceLoader.Load<PackedScene>("res://Minigames/GreitoRasymoMinigame/GameEnded.tscn");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
    public void GameEnded()
    {
        int score = global.typerScore;
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
