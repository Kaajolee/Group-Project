extends Node2D

@onready var interaction_area: InteractionArea = $InteractionArea


func _ready():
	
	interaction_area.interact = Callable(self, "_on_interact")
	
func _on_interact():
	Game.cordx = -300
	Game.cordy = -1105
	get_tree().change_scene_to_file("res://Main/Scenes/worlds/world.tscn")

