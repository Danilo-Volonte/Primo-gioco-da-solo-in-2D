extends Sprite2D
func _init():
	print("hello word")

var speed = 400
var velocitaAngolare = PI

func _process(delta):
	#rotation += velocitaAngolare * delta
	
	var direzione = 0
	if(Input.is_action_pressed("ui_left")):
		direzione = -1
	if(Input.is_action_pressed("ui_right")):
		direzione = 1
	rotation += velocitaAngolare * direzione *  delta 
	
	var velocita = Vector2.ZERO
	if(Input.is_action_pressed("ui_up")):
		velocita = Vector2.UP.rotated(rotation) * speed
	position += velocita * delta
	
	rotation += velocitaAngolare * direzione *  delta 
