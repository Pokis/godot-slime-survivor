using GettingstartedwithGodot4;
using Godot;
using System;
using System.IO;

public partial class SurvivorGame : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SpawnMob();
		SpawnMob();
		SpawnMob();
		SpawnMob();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public void SpawnMob()
    {
		var mob = ResourceHelper.CreateResource<Node2D>("monster");

		Random random = new Random();
		var pathFollow2D = GetNode<PathFollow2D>("%PathFollow2D");
        pathFollow2D.ProgressRatio = (float)random.NextDouble();

		mob.GlobalPosition = pathFollow2D.GlobalPosition;


        AddChild(mob);
    }

	public void OnPlayerHealthDepleted()
	{
        GetNode<CanvasLayer>("%GameOverScreen").Visible = true;
		GetTree().Paused = true;
    }

    public void OnTimerTimeout()
    {
        GD.Print("mob spawn timer timeout.");
		SpawnMob();
    }
}
