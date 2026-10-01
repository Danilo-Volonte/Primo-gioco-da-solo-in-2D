using Godot;
using System;

public partial class Bersaglio : Sprite2D
{
	public int vita = 100;
	public int Vita
	{
		set
		{
			if(value < 1) {	QueueFree();	}	//elimina il nodo
		}
		get {	return vita; }
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
