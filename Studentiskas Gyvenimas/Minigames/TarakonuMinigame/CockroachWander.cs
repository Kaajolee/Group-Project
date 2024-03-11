using Godot;
using System;
using System.Diagnostics;
using static Godot.TextServer;

public partial class CockroachWander : Node2D
{
	// Called when the node enters the scene tree for the first time.
	Random rnd;
	Tween tween;
	Sprite2D sprite;
	Timer timer;
	CockRoachInstantiation crInstantiation;
	public override void _Ready()
	{
        rnd = new Random();
		sprite = (Sprite2D)GetNode("Sprite2D");
	
        timer = (Timer)GetNode("Timer");


		float random = rnd.Next(8) / 10;
		if (random == 0)
		{
			timer.WaitTime = 0.3f;

		}
		else
			timer.WaitTime = random;

		//crInstantiation = GetTree().Root.GetNode<CockRoachInstantiation>("/root/HitTheBug/CockrachInstantiation");
        
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
	void OnTimerTimeout()
	{
		Vector2 nextPosition = PositionGenerator();
        tween = CreateTween();
        tween.TweenProperty(this, "position", nextPosition, 0.5f);
    }
	Vector2 PositionGenerator()
	{
		var currentViewport = GetViewport().GetVisibleRect().Size;
		Vector2 generatedPosition = new Vector2(rnd.Next((int)currentViewport.X), rnd.Next((int)currentViewport.Y));

		sprite.LookAt(generatedPosition);
        return generatedPosition;
	}
	void OnAreaInputEvent(Node viewport, InputEvent @event, int shape_idx)
	{
		if(@event is InputEventMouseButton mbEvent)
		{
			if(mbEvent.Pressed && mbEvent.ButtonIndex == MouseButton.Left)
			{
				AddScore();
				Debug.WriteLine("cockroach clicked");
                QueueFree();
				
            }

        }

	}
	void AddScore()
	{
		try
        {
            crInstantiation = GetNode("res://Minigames/TarakonuMinigame/HitTheBug.tscn");
            crInstantiation.score += 1;
			Debug.WriteLine("Score: " + crInstantiation.score);
		}
		catch (NullReferenceException)
		{
			Debug.Fail("Score script refference null");
		}
	}

}