extends Node2D

@onready var interaction_area: InteractionArea = $InteractionArea


func _ready():
	var player = load(Game.selected_character).instantiate()
	add_child(player)
		
	interaction_area.interact = Callable(self, "_on_interact")

func _on_interact():
	get_tree().change_scene_to_file("res://Main/Scenes/worlds/world2.tscn")





