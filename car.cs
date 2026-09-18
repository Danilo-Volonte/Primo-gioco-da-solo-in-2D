using Godot;
using System;


public partial class Car : CharacterBody2D
{
	public float maxSpeed;
	public float acceleration;
	public float engineBraking;
	public float rotationSpeed;
	public float speed = 0;
	public Label contachilometri;
	
	public float _maxSpeed
	{
		set
		{
			if(value < acceleration && value < engineBraking) { maxSpeed = value;}
			else { throw new ArgumentException("velocità troppo bassa");}
		}
	}
	public float _acceleration
	{
		set
		{
			if(value > 0){	acceleration = value; }
			else { throw new ArgumentException("accelerazione troppo bassa");}
		}
	}

	public float _engineBraking
	{
		set
		{
			if(value >= 0 && value <= acceleration){ engineBraking = value;}
			else { throw new ArgumentException("freno motore troppo alto o troppo basso");}
		}
	}

	public float _rotationSpeed
	{
		set
		{
			if(value > 0) {rotationSpeed = value;}
			else { throw new ArgumentException("rotazione troppo bassa");}
		}
	}
	
	public Car() { }   // costruttore vuoto richiesto da Godot
	
	public Car(float max_speed, float acc, float engine_braking, float rotation_speed)
	{
		_maxSpeed = max_speed;
		_acceleration = acc;
		_engineBraking = engine_braking;
		_rotationSpeed = rotation_speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		// comand
		if (Input.IsActionJustPressed("accelerate")){ speed += (float) (acceleration * delta);}
		else if(Input.IsActionJustPressed("brake")) { speed -= (float) (acceleration * delta); }
		else{ speed = (float) (Mathf.MoveToward(speed, 0.0, engineBraking * delta));}

		speed = Mathf.Clamp(speed, -maxSpeed * 0.5f, maxSpeed);
		
		float steerInput = Input.GetAxis("left", "right"); 
		float speedFactor = (float) (Mathf.Clamp(1.0 - Mathf.Abs(speed) / maxSpeed * 0.5, 0.5, 1.0));
		Rotation += (float) (steerInput * rotationSpeed * speedFactor * delta);
		Velocity = -Transform.Y * speed;
		Position += Velocity * (float) delta;
		contachilometri.Text = (string) ((Velocity/100) + "Km/h");
	}

	public override void _Ready()
	{
		contachilometri = GetNode<Label>("../CanvasLayer/Contachilometri");
	} 
}
