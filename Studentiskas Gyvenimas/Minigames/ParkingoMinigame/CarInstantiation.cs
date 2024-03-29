using Godot;
using System;
using System.Diagnostics;

public partial class CarInstantiation : Node2D
{

    // Called when the node enters the scene tree for the first time.

    [Export]
    public float parkingSpaceOffset;
    public float playerSpawnOffset = 50;

    PackedScene parkedCarScene;
    CustomSignals customSignals;
    Random rnd;
    Label label;

    float spawnLocationX;


    public bool isGameStopped;
    public override void _Ready()
    {
        parkedCarScene = ResourceLoader.Load<PackedScene>("res://Minigames/ParkingoMinigame/parkedCar.tscn");
        rnd = new Random();
        customSignals = GetNode<CustomSignals>("/root/CustomSignals");
        customSignals.ParkingMinigameEnded += CarCrashed;
        customSignals.ParkingMinigamePoint += PointEarned;
        

        //InstantiatePlayer();

        isGameStopped = false;

    }
    public override void _Process(double delta)
    {
    }
    void InstantiateCar()
    {
        int randomInt = rnd.Next(2);
        spawnLocationX = playerCarInstantiation.spawnDestinationX;
        Vector2 position = new Vector2(spawnLocationX, 0);
        Sprite2D scene = (Sprite2D)parkedCarScene.Instantiate();

        //masina
        if (randomInt == 0)
        {
            Sprite2D newSpriteCar = ChangeSprite(scene, true);
            scene = newSpriteCar;

        }
        //tuscia vieta
        else if (randomInt == 1)
        {
            position += new Vector2(parkingSpaceOffset, 0);
            Sprite2D newSpriteCar = ChangeSprite(scene, false);
            scene = newSpriteCar;
        }
        scene.Position = position;
        AddChild(scene);

    }
    void OnTimerTimeout()
    {
        if (isGameStopped == false)
            InstantiateCar();

    }
    Sprite2D ChangeSprite(Sprite2D currentSprite, bool isACar)
    {
        Sprite2D sprite2D = currentSprite;
        if (isACar == true)
        {
            sprite2D.Modulate = RandomColorGenerator();
        }
        else if (isACar == false)
        {
            sprite2D.Visible = false;

        }
        return sprite2D;
    }
    void CarCrashed()
    {
        isGameStopped = true;

    }
    void InstantiatePlayer()
    {
        spawnLocationX = playerCarInstantiation.spawnDestinationX;
        Vector2 position = new Vector2(GetWindow().Size.X / 2, GetWindow().Size.Y + playerSpawnOffset);
        Debug.WriteLine("Player pos: " + position);
        //Node2D playerSceneObj = (Node2D)playerScene.Instantiate();
        //playerSceneObj.Position = position;
        //AddChild(playerSceneObj);
    }
    void PointEarned()
    {
        //InstantiatePlayer();
        //isGameStopped = true;

    }
    public Color RandomColorGenerator()
    {
        byte r = (byte)rnd.Next(0, 256);
        byte g = (byte)rnd.Next(0, 256);
        byte b = (byte)rnd.Next(0, 256);
        byte a = 255;

        return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
    }

}
