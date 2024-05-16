extends Node2D


func _on_type_a_pressed():
	Game.selected_character = "res://Main/Player/PlayerA/player.tscn"
	Game.character = "a"
	get_tree().change_scene_to_file("res://Main/Scenes/worlds/world.tscn")

func _on_type_b_pressed():
	Game.selected_character = "res://Main/Player/PlayerB/player_b.tscn"
	Game.character = "b"
	get_tree().change_scene_to_file("res://Main/Scenes/worlds/world.tscn")
	
