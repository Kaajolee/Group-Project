extends Node2D

func _ready():

	var player = load(Game.selected_character).instantiate()
	add_child(player)






