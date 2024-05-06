extends CharacterBody2D

@onready var interaction_area: InteractionArea = $InteractionArea

func _ready():
	interaction_area.interact = Callable(self, "_on_interact")

func _on_interact():
	DialogueManager.show_example_dialogue_balloon(load("res://Dialogai/main_destytojas.dialogue"), "start")
	return
	#handle_dialogue_choice(1)
	
	#get_tree().quit()
#func handle_dialogue_choice(choice_index: int):
	#var balloon = preload("res://Minigames/ShellFolder(Mykolo)/world.tscn")
	##var dialogue = DialogueManager.get_current_dialogue()
	##if dialogue!=null:
		##var scene_path = dialogue.get_meta("ResourcePath")
	#
	#get_tree().change_scene_to_packed(balloon)
		#transition_to_scene(scene_path)
	#else:
		#DialogueManager.show_example_dialogue_balloon(load("res://Dialogai/main_destytojas.dialogue"), "start")
func handle_dialogue_choice(choice_index: int):
	var dialogue = DialogueManager.get_current_dialogue()
	if dialogue != null:
		var scene_path = dialogue.get_meta("ResourcePath")
		if scene_path != null:
			var required_scene = load(scene_path)
			if required_scene != null:
				get_tree().change_scene(required_scene)
			else:
					print("Error: Failed to load scene from", scene_path)
		else:
			print("Error: No scene path found in dialogue metadata")
	else:
		print("Error: No current dialogue found")


#func transition_to_scene(scene_path: String):
	#var required_scene = load(scene_path)
	#
	#if required_scene:
		#get_tree().change_scene_to_packed(required_scene)
	#else:
		#print("Klaida: nepavyko ikelti reikalingos scenos is", scene_path)
	
	#var scene_instance = load(scene_path).instance()
	#get_tree().get_root().add_child(scene_instance)

#func get_scene_path_from_dialogue(default_path: String) -> String:
	#var dialogue = DialogueManager.get_current_dialogue()
	#if dialogue.has_meta("ResourcePath"):
		#return dialogue.get_meta("ResourcePath")
	#else:
			#return default_path
