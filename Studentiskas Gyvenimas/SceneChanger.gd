extends Node


# Called when the node enters the scene tree for the first time.
func _ready():
	
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

func handle_dialogue_choice(choice_index: int):

	match choice_index:
		0:  # Knygos
			load_and_change_scene("res://Minigames/ShellFolder(Mykolo)/world.tscn")
		1:  # Greitas rašymas
			load_and_change_scene("res://Minigames/GreitoRasymoMinigame/ButtonSmasher.tscn")
		2:  # Tarakonų gaudymas
			load_and_change_scene("res://Minigames/TarakonuMinigame/HitTheBug.tscn")
		3:  # Parkingas
			load_and_change_scene("res://Minigames/ParkingoMinigame/ParkTheCar.tscn")
		4:  # Pradeti iš naujo
			return  # Reset dialogue to its initial state
		5:  # Pabaigti pokalbį
			return

# You can define helper functions to load and change scenes
func load_and_change_scene(scene_path: String):
	#var scene = ResourceLoader.load(scene_path)
	var scene = load(scene_path)
	if scene != null:
		get_tree().change_scene_to_packed(scene)
	else:
		print("Error: Failed to load scene:", scene_path)
