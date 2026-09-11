extends CharacterBody2D

@export var max_speed: float = 400.0
@export var acceleration: float = 160.0
@export var engine_braking: float = 200.0
@export var rotation_speed: float = 3.0

var speed: float = 0.0

func _physics_process(delta):
	# Accelerazione / frenata
	if Input.is_action_pressed("accelerate"):
		speed += acceleration * delta
	elif Input.is_action_pressed("brake"):
		speed -= acceleration * delta
	else:
		speed = move_toward(speed, 0.0, engine_braking * delta)

	speed = clamp(speed, -max_speed * 0.5, max_speed)  # retromarcia più lenta

	# Sterzata: legge left/right indipendentemente dal gas
	var steer_input = Input.get_axis("left", "right")
	var steer_factor = clamp(abs(speed) / max_speed, 0.3, 1.0)
	rotation += steer_input * rotation_speed * steer_factor * delta

	velocity = -transform.y * speed
	position += velocity * delta
	
	
