using Godot;
using System;


public partial class Car : CharacterBody2D
{
	public double maxSpeed;
	public double acceleration;
	public double engineBraking;
	public double rotationSpeed;
	public float speed = 0;
	public const double contachilometri = GetNode<Label>("../CanvasLayer/Contachilometri");
	
	public double _maxSpeed
	{
		set
		{
			if(value < acceleration && value < engineBraking) { maxSpeed = value;}
			else { throw new ArgumentException("velocità troppo bassa");}
		}
	}
	public double _acceleration
	{
		set
		{
			if(value > 0){	acceleration = value; }
			else { throw new ArgumentException("accelerazione troppo bassa");}
		}
	}

	public double _engineBraking
	{
		set
		{
			if(value >= 0 && value <= acceleration){ engineBraking = value;}
			else { throw new ArgumentException("freno motore troppo alto o troppo basso");}
		}
	}

	public double _rotationSpeed
	{
		set
		{
			if(value > 0) {rotationSpeed = value;}
			else { throw new ArgumentException("rotazione troppo bassa");}
		}
	}

	public Car(double max_speed, double acc, double engine_braking, double rotation_speed)
	{
		_maxSpeed = max_speed;
		_acceleration = acc;
		_engineBraking = engine_braking;
		_rotationSpeed = rotation_speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		// comand
		if (Input.IsActionJustPressed("accelerate")){ speed += acceleration * delta;}
		else if(Input.IsActionJustPressed("brake")) { speed -= acceleration * delta; }
		else{ speed = Mathf.MoveToward(speed, 0.0, engineBraking * delta);}

		speed = Mathf.Clamp(speed, -maxSpeed * 0.5f, maxSpeed);
		
		double steerInput = Input.GetAxis("left", "right"); 
		double speedFactor = Mathf.Clamp(1.0 - Mathf.Abs(speed) / maxSpeed * 0.5, 0.5, 1.0);
		Rotation += (float) (steerInput * rotationSpeed * speedFactor * delta);
		Velocity = -Transform.Y * speed;
		Position += Velocity * delta;
		contachilometri.text = (string) ((Velocity/100) + "Km/h");
	}
}
