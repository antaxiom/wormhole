extends Node2D

@onready var V3D := $"SubViewport/3D/CSGTorus3D"

func _ready():
	pass

func _process(delta):
	V3D.rotation.y += 1 * delta
