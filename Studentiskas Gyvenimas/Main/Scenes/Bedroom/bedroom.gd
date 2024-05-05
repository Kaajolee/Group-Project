extends Node2D

func _ready():
	var player = load(Game.selected_character).instantiate()
	#DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_MAXIMIZED)
	add_child(player)
	player.position = Vector2(530, 310)
