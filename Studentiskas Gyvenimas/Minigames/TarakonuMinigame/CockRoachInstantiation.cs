using Godot;
using System;
using System.Diagnostics;
using System.Linq.Expressions;

public partial class CockRoachInstantiation : Node2D
{
	// Called when the node enters the scene tree for the first time.
	PackedScene cockRoachScene;
    Random rnd;
    public int score;
    Label scoreLabel;



	public override void _Ready()
	{
        cockRoachScene = ResourceLoader.Load<PackedScene>("res://Minigames/TarakonuMinigame/CockRoach.tscn");
        scoreLabel = GetNode<Label>("CanvasLayer/Panel/Label");
        //scoreLabel = GetNode<Label>("Control/Label");

        rnd = new Random();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        UpdateLabelText();
	}
	void OnTimerTimeout()
	{
        InstantiateCockroach();
    }
    void InstantiateCockroach()
    {
        Debug.WriteLine("--------------------------");
        Vector2 position = PositionGenerator();
        Node2D scene = (Node2D)cockRoachScene.Instantiate();
        float randomFloat = rnd.NextSingle();
        float randomScale = randomFloat <= 0.2f ? 0.2f : randomFloat;
        Debug.WriteLine("Scale: " + randomScale);
        scene.Scale = new Vector2(randomScale, randomScale);
        scene.Position = position;

        Debug.WriteLine(Global.cockroachScore.ToString());

        AddChild(scene);

        Debug.WriteLine($"Object instantiated: {position}, scale: {randomScale}");
    }
    Vector2 PositionGenerator()
    {
        var currentViewport = GetViewport().GetVisibleRect().Size + new Vector2(100,100);
        Vector2 generatedPosition = new Vector2();
        switch (rnd.Next(4))
        {
            case 0:
                generatedPosition = new Vector2(rnd.Next((int)currentViewport.X), 0);
                break;
            case 1:
                generatedPosition = new Vector2(currentViewport.X, 0);
                break;
            case 2:
                generatedPosition = new Vector2(rnd.Next((int)currentViewport.X), currentViewport.Y);
                break;
            case 3:
                generatedPosition = new Vector2(0, rnd.Next((int)currentViewport.Y));
                break;
        }
        return generatedPosition;

    }
    void UpdateLabelText()
    {
        scoreLabel.Text = "Score: " + Global.cockroachScore.ToString();
    }

}
