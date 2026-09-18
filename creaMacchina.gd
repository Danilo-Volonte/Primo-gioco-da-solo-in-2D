extends Node
var macchina: Car

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	macchina = Car.new()
	macchina.creaContachilometri()
	add_child(macchina);  #altrimenti l'auto esiste in memoria ma non appare nel gioco
	macchina.Initialize(1000, 260, 200, 2)

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass
