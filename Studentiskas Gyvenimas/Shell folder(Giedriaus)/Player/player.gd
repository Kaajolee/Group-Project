extends CharacterBody2D

var SPEED = 300.0

func _physics_process(_delta):
	var direction = Input.get_vector("ui_left", "ui_right", "ui_up", "ui_down")
	velocity = direction * SPEED
	if velocity.y == 0 && velocity.x == 0:
		get_node("AnimatedSprite2D").play("Idle")
	
	if velocity.y == 0 && velocity.x < 0:
		get_node("AnimatedSprite2D").play("Left")	
		
	if velocity.y > 0:
		get_node("AnimatedSprite2D").play("Down")	
		
	if velocity.y == 0 && velocity.x > 0:
		get_node("AnimatedSprite2D").play("Right")
		
	if velocity.y < 0 :
		get_node("AnimatedSprite2D").play("Up")
		##-------------------------------------
	move_and_slide()
