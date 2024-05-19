extends CharacterBody2D

@onready var interaction_area: InteractionArea = $InteractionArea

func _ready():
	interaction_area.interact = Callable(self, "_on_interact")

func _on_interact():
	if Game.books == "0":
		DialogueManager.show_example_dialogue_balloon(load("res://Dialogai/studente.dialogue"), "start")
	elif Game.books == "1": 
		Game.books == "2"
		DialogueManager.show_example_dialogue_balloon(load("res://Dialogai/studente2.dialogue"), "start")
	return
