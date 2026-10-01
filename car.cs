using Godot;
using System;
using System.Globalization;   // riga per la virgola

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
	
	[Export] public float _maxSpeed
	{
		set
		{
			if(value > acceleration && value > engineBraking) { maxSpeed = value;}
			else { throw new ArgumentException("velocità troppo bassa");}
		}
		get { return maxSpeed;}
	}
	[Export] public float _acceleration
	{
		set
		{
			if(value > 0 && value > engineBraking){	acceleration = value; }
			else { throw new ArgumentException("accelerazione troppo bassa");}
		}
		get { return acceleration;}
	}

	[Export] public float _engineBraking
	{
		set
		{
			if(value >= 0 && value <= acceleration){ engineBraking = value;}
			else { throw new ArgumentException("freno motore troppo alto o troppo basso");}
		}
		get { return engineBraking;}
	}

	[Export] public float _rotationSpeed
	{
		set
		{
			if(value > 0) {rotationSpeed = value;}
			else { throw new ArgumentException("rotazione troppo bassa");}
		}
		get { return rotationSpeed;}	
	}
	
	public Car()
	{
		Label contachilometri = new Label();

		contachilometri.Name = "Contachilometri";

		AddChild(contachilometri);
	}   // costruttore vuoto richiesto da Godot
	
	public void Initialize(float max_speed, float acc, float engine_braking, float rotation_speed)
	{
		_maxSpeed = max_speed;
		_acceleration = acc;
		_engineBraking = engine_braking;
		_rotationSpeed = rotation_speed;
		Label contachilometri = new Label();
		contachilometri.Name = "Contachilometri";
		AddChild(contachilometri);
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
		if(contachilometri != null) {	contachilometri.Text = $"{(Velocity.Length() / 100).ToString("F0", CultureInfo.InvariantCulture)} Km/h";	}
		else {	GD.Print(contachilometri);	}
	}

	public override void _Ready(){	contachilometri = GetNode<Label>("UI/Contachilometri");	}

	public void creaContachilometri(Label posto) { contachilometri = posto; } 
	public string stampa() { return "velocità massima: {maxSpedd} /n accelerazione: {acceleration} /n freno motore: {engineBraking} /n velocità rotazione: {rotationSpeed} /n"; }
}
