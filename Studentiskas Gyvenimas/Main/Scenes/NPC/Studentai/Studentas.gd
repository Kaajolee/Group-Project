extends CharacterBody2D

@onready var interaction_area: InteractionArea = $InteractionArea

func _ready():
	interaction_area.interact = Callable(self, "_on_interact")

func _on_interact():
	DialogueManager.show_example_dialogue_balloon(load("res://Dialogai/studentai.dialogue"), "start")
	return
