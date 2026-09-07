extends Node2D
var speed = 400
var velocitaAngolare = PI

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	if(Input.is_action_pressed("left")):
		$Player.position.x -= 1
		print($Player.position)
	if(Input.is_action_pressed("right")):
		$Player.position.x += 1
		print($Player.position)
	if(Input.is_action_pressed("up")):
		$Player.position.y -= 1
		print($Player.position)
	if(Input.is_action_pressed("down")):
		$Player.position.y += 1
		print($Player.position)
	#rotation += velocitaAngolare * direzione *  delta 
	
	#var velocita = Vector2.ZERO
	#if(Input.is_action_pressed("ui_up")):
		#velocita = Vector2.UP.rotated(rotation) * speed
	#position += velocita * delta
	
	#rotation += velocitaAngolare * direzione *  delta 
