using Godot;
using System;
using System.Diagnostics;

public partial class Settings : Panel
{
	// Called when the node enters the scene tree for the first time.
	Global global;

	private HSlider masterSlider;
	private HSlider musicSlider;

	private MenuButton menuButton;

	private float musicSliderValue;
	private float masterSliderValue;

	public override void _Ready()
	{
        global = GetNode<Global>("/root/Global");

		musicSlider = GetNode<HSlider>("./SoundContainer/musicSlider");
		musicSlider = GetNode<HSlider>("./SoundContainer/masterSlider");

		menuButton = GetNode<MenuButton>("./ScreenSizeContainer/MenuButton");

		menuButton.GetPopup().add

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void ApplySettings()
	{

	}
	public void OnMusicVolumeChanged(float value)
	{
		musicSliderValue = value;
    }
    public void OnMasterVolumeChanged(float value)
    {
        masterSliderValue = value;
		Debug.WriteLine(value);
    }
}
