extends CharacterBody2D


@export var speed = 400


func _physics_process(delta: float) -> void:
	if(Input.is_action_pressed("left")):
		position.x -= 1
		
	if(Input.is_action_pressed("right")):
		position.x += 1
		
	if(Input.is_action_pressed("up")):
		position.y -= 1
		
	if(Input.is_action_pressed("down")):
		position.y += 1
		
		
	get_input()
	#rotation += rotation_direction * rotation_speed * delta
	move_and_slide()
	


func get_input():
	var input_direction = Input.get_vector("left", "right", "up", "down")
	velocity = input_direction * speed
