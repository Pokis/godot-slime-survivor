using GettingstartedwithGodot4;
using Godot;
using System;

public partial class bullet : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	double travelledDistance = 0;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		const float SPEED = 1000;
		const float RANGE = 1200;

		var direction = Vector2.Right.Rotated(Rotation);
		Position += direction * SPEED * (float) delta;

		travelledDistance += SPEED * delta;
		if(travelledDistance > RANGE)
		{
			QueueFree();
		}
	}

	public void OnBodyEntered(Node2D caller)
	{
        QueueFree();
		if(caller.HasMethod(new StringName("TakeDamage")))
		{
			caller.Call("TakeDamage");
		}
	}
}
