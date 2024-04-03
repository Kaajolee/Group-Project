using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 400.0f;
	public const float JumpVelocity = -400.0f;
	public bool isGameFinished = false;
	CustomSignals customSignals;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	AnimatedSprite2D animations;

	public string playerGender = "b";

	public override void _Ready()
	{
		customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		customSignals.BookMinigameEnded += () => gameFinished();
		switch (playerGender) 
		{
			case "a":
				animations = GetNode<AnimatedSprite2D>("Berniukas");
				break;
			case "b":
				animations = GetNode<AnimatedSprite2D>("Mergina");
				break;
		}
		animations.Visible = true;

		//animations = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{

		if (isGameFinished)
		{
			return;
		}

		Vector2 velocity = Velocity;

		// Add the gravity.
		//if (!IsOnFloor())
		//	velocity.Y += gravity * (float)delta;

		// Handle Jump.
		//if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		//	velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		if (Input.IsActionPressed("ui_left"))
			animations.Play("walk_left");
		else if (Input.IsActionPressed("ui_right"))
			animations.Play("walk_right");
		else
			animations.Play("idle");


		Velocity = velocity;
		MoveAndSlide();
		var collision = MoveAndCollide(Velocity * (float)delta);
		if (collision != null)
		{
			//if (collision.GetCollider().ToString() == "<StaticBody2D#27715962064>")
		   // if (collision.GetCollider() is Book)
			//{
		   //     GD.Print(collision.GetCollider().GetType());
		   //     Score++;
		   //     GD.Print("KNYGA! Score:" + Score);
		  //  }
			//else { GD.Print("NEPAVYKO " + collision.GetCollider().GetType()); }
		}

	}

	void gameFinished()
	{
		isGameFinished = true;
	}
}
