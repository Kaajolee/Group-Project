extends Node2D


func _ready():
	var player = load(Game.selected_character).instantiate()
	add_child(player)
	Game.last_location = "first_floor"
	player.position = Vector2(-125, -125)
