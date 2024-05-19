extends Node2D


func _ready():
	BgMusic.Play("Song1")
	var player = load(Game.selected_character).instantiate()
	add_child(player)
	player.position = Vector2(Game.cordx, Game.cordy)
	if Game.dialogue == "GameStart":
		DialogueManager.show_example_dialogue_balloon(load("res://Dialogai/gamestart.dialogue"))
		
		Game.dialogue = "NULL"

