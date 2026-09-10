extends CharacterBody2D

@export var speed = 400
@export var rotation_speed = 1.5
@export var acceleration := 200.0
@export var brake := 300.0
@export var max_speed := 1000.0
@export var engineBraking := 100.0

@onready var contachilometri = $"../CanvasLayer/Contachilometri"

var rotationDirection = 0

func _physics_process(delta: float) -> void:

	if Input.is_action_pressed("up"):
		velocity -= transform.y * acceleration * delta

	if Input.is_action_pressed("down"):
		velocity += transform.y * brake * delta

	velocity = velocity.limit_length(max_speed)

	get_input()

	rotation += rotationDirection * rotation_speed * delta

	move_and_slide()
	
	contachilometri.text = str(int(velocity.length())) + " Km/h"

func get_input():
	var input_direction = Input.get_axis("left", "right")
