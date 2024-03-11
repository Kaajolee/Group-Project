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

    [Export]
    public int CharacterCap;
    
    private Random rnd = new Random();
    public override void _Ready()
	{
        inputEnabled = true;
        timeStart = Time.GetTicksMsec();
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
            //Debug.WriteLine(@event.AsText());
		//Text += @event.AsText();

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
        int textLength = Text.Length;
        if (textLength >= CharacterCap)
        {
            Debug.WriteLine("CHARACTER LIMIT REACHED");
            inputEnabled = false;
            PointCounter();
        }
            
    }
    void PointCounter()
    {
        float elapsedTime = Time.GetTicksMsec() - timeStart;
        int pointAmount = Mathf.RoundToInt(elapsedTime / 1000);
        Debug.WriteLine(pointAmount);

    }
    
}
