extends Area2D

var SPEED = randi_range(-500, 500)
var velocity = Vector2()

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _physics_process(delta):
	
	position.x += SPEED * delta
	
