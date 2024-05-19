using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;

public partial class bg_music : Node
{
	public static bg_music Instance { get; private set; }

    private Dictionary<string, AudioStreamPlayer> music = new Dictionary<string, AudioStreamPlayer>();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		Instance = this;

        foreach (Node child in GetChildren())
        {
            music.Add(child.Name, (AudioStreamPlayer)child);

        }

        foreach (KeyValuePair<string, AudioStreamPlayer> entry in music)
        {
            entry.Value.Finished += () => Instance.Play(entry.Key);
        }

        Instance.Play("Song1");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public void Play(string name)
    {
        if (!music.ContainsKey(name))
            return;

        foreach (KeyValuePair<string, AudioStreamPlayer> entry in music)
        {
            // If the current song is not the one we want to play, stop it
            if (entry.Key != name)
            {
                entry.Value.Stop();
            }
        }

        // Only play the song if it's not already playing
        if (!music[name].Playing)
        {
            music[name].Play();
        }
    }
}
