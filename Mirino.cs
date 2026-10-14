using Godot;
using System;

public partial class Mirino : Polygon2D
{
	public float aimSpeed = 500f;   // gradi al secondo (più basso = arma più pesante)
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// 1. Angolo desiderato: dal mirino verso il mouse
		Vector2 direzione = GetGlobalMousePosition() - GlobalPosition;
		float angoloDesiderato = direzione.Angle();

		// 2. Ruota verso quell'angolo, con un limite di velocità
		float passoMassimo = Mathf.DegToRad(aimSpeed) * (float)delta;
		GlobalRotation = Mathf.RotateToward(GlobalRotation, angoloDesiderato, passoMassimo);
	}
}
