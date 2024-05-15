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

	private float musicSliderValue = 0;
	private int screenType = 0;


	public override void _Ready()
	{
		global = GetNode<Global>("/root/Global");

		musicSlider = GetNode<HSlider>("./Content/musicSlider");

		menuButton = GetNode<MenuButton>("./Content/ScreenTypeButton");
		menuButton.Connect("id_pressed", new Callable(this, MethodName.ScreenType));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
	public void ApplySettings()
	{
		//AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Master"), AudioServer.)
		ScreenTypeSelected(screenType);
	}
	public void OnMusicVolumeChanged(float value)
	{
		musicSliderValue = value;
	}
	public void BackButtonPressed()
	{
		Visible = !Visible;
	}
	public void ScreenType(int id)
	{
		Debug.WriteLine("Screen type button pressed");
		//screenType = id;
	}
	void ScreenTypeSelected(int index)
	{
		if (index == 0)
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);

		else if (index == 1)
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Maximized);

		else
			throw new Exception("Error setting the screen type");

    }
}
