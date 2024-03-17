extends Area2D

var SPEED = 300 
var velocity = Vector2()

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _physics_process(delta):
	velocity.x += SPEED * delta
	position.x += velocity.x * delta
	

