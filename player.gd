class_name Car
extends CharacterBody2D

@export var max_speed: float:
	set(value):
		if(value < acceleration and value < engine_braking):
			push_error("velocità massima troppo bassa")
		else: 
			max_speed = value
			
@export var acceleration: float:
	set(value):
		if(value <= 0):
			push_error("accelerazione troppo bassa")
		else: 
			acceleration = value 
			
@export var engine_braking: float:
	set(value):
		if(value <= 0):
			push_error("freno motore troppo basso")
		else:
			engine_braking = value
			
@export var rotation_speed: float:
	set(value):
		if(value <= 0):
			push_error("angolazione troppo bassa")
		else:
			rotation_speed = value

@onready var contachilometri = $"../CanvasLayer/Contachilometri"

var speed: float = 0.0

func _init(maxSpeed, acc, engineBraking, rotationSpeed):
	acceleration = acc
	engine_braking = engineBraking
	rotation_speed = rotationSpeed
	max_speed = maxSpeed

func _physics_process(delta):
	# Accelerazione / frenata
	if Input.is_action_pressed("accelerate"):
		speed += acceleration * delta
	elif Input.is_action_pressed("brake"):
		speed -= acceleration * delta
	else:
		speed = move_toward(speed, 0.0, engine_braking * delta)

	speed = clamp(speed, -max_speed * 0.5, max_speed)  # retromarcia più lenta

	# Sterzata: legge left/right e gas
	var steer_input = Input.get_axis("left", "right")
	var speed_factor = clamp(1.0 - abs(speed) / max_speed * 0.5, 0.5, 1.0)
	rotation += steer_input * rotation_speed * speed_factor * delta

	velocity = -transform.y * speed
	position += velocity * delta
	contachilometri.text = str(int(velocity.length()/100)) + " Km/h"
	
	
var macchina = Car.new(1000, 260, 200, 2)
