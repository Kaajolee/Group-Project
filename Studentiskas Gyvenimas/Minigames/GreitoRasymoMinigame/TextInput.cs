using Godot;
using System;
using System.Diagnostics;

public partial class TextInput : RichTextLabel
{
	// Called when the node enters the scene tree for the first time.
	private const int MinWordLength = 3;
    private const int MaxWordLength = 7;
	private const char MinChar = '!';
    private const char MaxChar = 'z';
    private const char SpaceChar = ' ';

    private float timeStart;

    public bool inputEnabled;
    private bool isGameEnded;

    private CustomSignals customSignals;
    private PackedScene gameEndedScene;
    [Export]
    public int CharacterCap;

    [Export]
    public int PointBase;

    private Random rnd = new Random();
    public override void _Ready()
	{
        inputEnabled = true;
        isGameEnded = false;
        timeStart = Time.GetTicksMsec();
        customSignals = GetNode<CustomSignals>("/root/CustomSignals");
        gameEndedScene = ResourceLoader.Load<PackedScene>("res://Minigames/GreitoRasymoMinigame/GameEnded.tscn");
        //gameEndedWindowLabel = GetNode<Label>();

        customSignals.TyperMinigameEnded += GameEnded;

    }

    public override void _Input(InputEvent @event)
    {
        if(inputEnabled)
		    GenerateText(@event);
    }
    public override void _Process(double delta)
	{
        TextCheck();
	}
	void GenerateText(InputEvent @event)
	{
        if (@event is InputEventKey keyEvent && keyEvent.Echo == false)
        {
            Text += GenerateRandomWord(rnd.Next(MinWordLength, MaxWordLength));
        }

    }
    string GenerateRandomWord(int length)
    {
        string word = "";

        for (int i = 0; i < length; i++)
        {
            char randomChar = (char)rnd.Next(MinChar, MaxChar + 1);
            word += randomChar;
        }
        word += SpaceChar;
        return word;
        
    }
    void TextCheck()
    {
        if (isGameEnded == false)
        {
            int textLength = Text.Length;
            if (textLength >= CharacterCap)
            {
                Debug.WriteLine("CHARACTER LIMIT REACHED");
                customSignals.EmitSignal(nameof(CustomSignals.TyperMinigameEnded));
                inputEnabled = false;
                isGameEnded = true;
            }
        }

            
    }
    public void GameEnded()
    {
        int score = PointCounter();
        Debug.WriteLine("event triggered");
        InstantiateWindow(gameEndedScene, score);
    }
    int PointCounter()
    {
        float elapsedTime = Time.GetTicksMsec() - timeStart;
        int elaTimeInt = Mathf.RoundToInt(elapsedTime / 1000);
        int pointAmount = PointBase - elaTimeInt < 0 ? 0 : PointBase - elaTimeInt;
        Debug.WriteLine("Total score: " + pointAmount);
        return pointAmount;

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
