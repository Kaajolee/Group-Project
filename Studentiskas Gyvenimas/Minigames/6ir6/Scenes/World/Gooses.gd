extends Node2D

#var goose = preload("res://Minigames/6ir6/Scenes/goose.tscn")
var gosling = preload("res://Minigames/6ir6/Scenes/gosling.tscn")




func _ready():
	var goose = load("res://Minigames/6ir6/Scenes/goose.tscn").instantiate()
	add_child(goose)
	goose.position = Vector2(100, randi_range(50,550))

