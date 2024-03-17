extends Node2D

var goose = preload("res://Minigames/6ir6/Scenes/goose.tscn")
var gosling = preload("res://Minigames/6ir6/Scenes/gosling.tscn")

var LSpeed = randi_range(-500, 120)
var RSpeed = randi_range(120, -500)

# 1 - left || 2 - right
var amount_goose = randi_range(1, 5)
var amount_gosling = 10-amount_goose



var total_gooses = amount_goose+amount_gosling

func _ready():
	print(amount_gosling)
	for n in range(amount_goose):
		var gooseTemp = goose.instantiate()
		#gooseTemp.position = Vector2(1000, randi_range(20, 520))
		if randi_range(1, 2) == 1:
			# 1 - left || 2 - right
			gooseTemp.position = Vector2(100, randi_range(20, 520))
		else:
			gooseTemp.position = Vector2(1000, randi_range(20, 520))
			#gooseTemp.position.x = RSpeed*delta
		add_child(gooseTemp)
	
	for n in range(amount_gosling):
		var goslingTemp = gosling.instantiate()
		if randi_range(1, 2) == 1:
			# 1 - left || 2 - right
			goslingTemp.position = Vector2(100, randi_range(20, 520))
			#goslingTemp.position.x = LSpeed*delta
		else:
			goslingTemp.position = Vector2(1000, randi_range(20, 520))
			#goslingTemp.position.x = RSpeed*delta
		add_child(goslingTemp)

func _physics_process(delta):
	
	pass
