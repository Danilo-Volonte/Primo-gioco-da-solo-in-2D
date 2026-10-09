using Godot;
using System;

public partial class Health : Node
{
	int vita;
	int maxVita;
	public event Action Died;
	
	int _vita
	{
		get{ return vita;}
		set
		{
			if(value < 1) {	Died?.Invoke(); } //emette il segnale e quando viene invocato senza che nessuno scolata il segnale non dà errore
		}
	}
	
	public Health(int vita_, int maxVita_) 
	{
		if(vita_ > 10 && vita_ < maxVita_)
		{
			vita = vita_;
			maxVita = maxVita_;
		}
	}
	
	public void danno(int danno) { vita -= danno;}
	public void cura(int cura) 
	{
		if(vita + cura <= maxVita) { vita += cura;} 
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
