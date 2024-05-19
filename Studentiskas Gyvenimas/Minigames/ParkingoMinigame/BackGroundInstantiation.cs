using Godot;
using System;

public partial class BackGroundInstantiation : Node2D
{
	Sprite2D backgroundSprite;
	Sprite2D backgroundSpriteCopy;
	Vector2 instPos;
    float fallSpeed;
    Vector2 rectSize;
    Vector2 spritePos;
    public override void _Ready()
	{
		backgroundSprite = GetNode<Sprite2D>("./Sprite2D");
        instPos = GetNode<Node2D>("./Node2D").Position;
        rectSize = GetViewportRect().Size;
        backgroundSpriteCopy = backgroundSprite;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        fallSpeed = objectFallScript.fallSpeed;

        if (spritePos.Y >= rectSize.Y + 85)
        {
            backgroundSpriteCopy.QueueFree();
            Instantiatebackground();
        }
        spritePos = backgroundSpriteCopy.Position;
        spritePos.Y += fallSpeed;
        backgroundSpriteCopy.Position = spritePos;
    }
    void Instantiatebackground()
    {
        Sprite2D bg = backgroundSprite;
        bg.Position = instPos;
        AddChild(bg);
    }
}
