using Godot;
using System;

public partial class CockRoachInstantiation : Node2D
{
	// Called when the node enters the scene tree for the first time.
	PackedScene cockRoachScene;
    Random rnd;
    public static int score;
    Label scoreLabel;
	public override void _Ready()
	{
        cockRoachScene = ResourceLoader.Load<PackedScene>("res://CockRoach.tscn");
        scoreLabel = GetNode<Label>("Control/Label");
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
        Vector2 position = PositionGenerator();
        Node2D scene = (Node2D)cockRoachScene.Instantiate();
        scene.Position = position;
        AddChild(scene);

        //Debug.WriteLine("Object instantiated | pos : " + position.ToString());
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
        scoreLabel.Text = "Score: " + score;
    }

}
