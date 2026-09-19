extends Node2D


#func get_input():
	#rotation_direction = Input.get_axis("left", "right")
	#velocity = transform.x * Input.get_axis("down", "up") * speed

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	var player = $Player
	print(player.macchina.stampa())   # usa il nome esatto che hai dato alla variabile in creaMacchina.gd
	player.macchina.contachilometri = get_node("CanvasLayer/Contachilometri");

func _process(_delta: float) -> void:
	pass
