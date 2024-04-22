extends Node2D




func _ready():
	var player = load(Game.selected_character).instantiate()
	if Game.last_location == "first_floor" :
		add_child(player)
		#player.position = Vector2(425, 150)
	else: 
		add_child(player)
		
	
	







