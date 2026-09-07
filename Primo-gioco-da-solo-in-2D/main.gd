extends Node2D
var speed = 400
var velocitaAngolare = PI

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
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
