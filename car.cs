using Godot;
using System;

//per trovare tutte le classi
[GlobalClass] 
public partial class Car : CharacterBody2D
{
	public float maxSpeed;
	public float acceleration;
	public float engineBraking;
	public float rotationSpeed;
	public float speed = 0;
	public Label contachilometri;
	
	[export] public float _maxSpeed
	{
		set
		{
			if(value > acceleration && value > engineBraking) { maxSpeed = value;}
			else { throw new ArgumentException("velocità troppo bassa");}
		}
	}
	[export] public float _acceleration
	{
		set
		{
			if(value > 0 && value > engineBraking){	acceleration = value; }
			else { throw new ArgumentException("accelerazione troppo bassa");}
		}
	}

	[export] public float _engineBraking
	{
		set
		{
			if(value >= 0 && value <= acceleration){ engineBraking = value;}
			else { throw new ArgumentException("freno motore troppo alto o troppo basso");}
		}
	}

	[export] public float _rotationSpeed
	{
		set
		{
			if(value > 0) {rotationSpeed = value;}
			else { throw new ArgumentException("rotazione troppo bassa");}
		}
	}
	
	public Car() { }   // costruttore vuoto richiesto da Godot
	
	public void Initialize(float max_speed, float acc, float engine_braking, float rotation_speed)
	{
		_maxSpeed = max_speed;
		_acceleration = acc;
		_engineBraking = engine_braking;
		_rotationSpeed = rotation_speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		// comand
		if (Input.IsActionPressed("accelerate")){ speed += (float) (acceleration * delta);}
		else if(Input.IsActionPressed("brake")) { speed -= (float) (acceleration * delta); }
		else{ speed = (float) (Mathf.MoveToward(speed, 0.0, engineBraking * delta));}

		speed = Mathf.Clamp(speed, -maxSpeed * 0.5f, maxSpeed);
		
		float steerInput = Input.GetAxis("left", "right"); 
		float speedFactor = (float) (Mathf.Clamp(1.0 - Mathf.Abs(speed) / maxSpeed * 0.5, 0.5, 1.0));
		Rotation += (float) (steerInput * rotationSpeed * speedFactor * delta);
		Velocity = -Transform.Y * speed;
		Position += Velocity * (float) delta;
		contachilometri.Text = contachilometri.Text = $"{Velocity.Length() / 100} Km/h";
	}

	public void creaContachilometri() { contachilometri = GetNode<Label>("../CanvasLayer/Contachilometri"); } 
	public string stampa() { return "velocità massima: {maxSpedd} /n accelerazione: {acceleration} /n freno motore: {engineBraking} /n velocità rotazione: {rotationSpeed} /n"; }
}
