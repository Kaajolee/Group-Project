using Godot;
using System;
using System.Diagnostics;

public partial class objectFallScript : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	public float speed;
    private float screenBottomY;

    private Sprite2D sprite;
	private Tween tween;

	
	public override void _Ready()
	{
        sprite = GetNode<Sprite2D>(".");
		screenBottomY = GetViewportRect().Size.Y;

        //tween = CreateTween();
        //MoveSprite();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        screenBottomY = GetViewportRect().Size.Y;

		var position = Position;

        position.Y += speed * (float)delta * 50;
		Position = position;

		if (Position.Y >= screenBottomY)
			QueueFree();

	}
	private void MoveSprite()
	{
        //Vector2 spritePos = sprite.Position;
        //Vector2 shiftedPos = new Vector2(spritePos.X, spritePos.Y + tweenDestination);
    }
	void OnTimerTimeout()
	{
        //Vector2 spritePos = sprite.Position;
		//float Xlerp = Mathf.Lerp(spritePos.Y, spritePos.Y + deltaY, lerpTime);
        //Vector2 shiftedPos = new Vector2(spritePos.X, Xlerp);
		//Position = shiftedPos;
        //Debug.Write("test");
	}





}
