extends Node2D

@onready var interaction_area: InteractionArea = $InteractionArea
var player = load(Game.selected_character).instantiate()

func _ready():
	
	
	interaction_area.interact = Callable(self, "_on_interact")
	
func _on_interact():
	get_tree().change_scene_to_file("res://Main/Scenes/worlds/world.tscn")
	

