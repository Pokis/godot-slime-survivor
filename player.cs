using GettingstartedwithGodot4;
using Godot;
using System;
using System.Linq;

public partial class player : CharacterBody2D
{

    double health = 100;

    [Signal]
    public delegate void HealthDepletedEventHandler();

    public override void _PhysicsProcess(double delta)
    {
        base._Process(delta);
       
        var direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
        Velocity = direction * 600;
        MoveAndSlide();
       
        if(Velocity.Length() > 0)
        {
            GetNode("HappyBoo").Call("play_walk_animation");
        }
        else
        {
            GetNode("HappyBoo").Call("play_idle_animation");
        }

        const int damageRate = 50;
        var overlappingMobs = GetNode<Area2D>("HurtBox").GetOverlappingBodies();
       
        if (overlappingMobs.Any())
        {
            health-= damageRate * overlappingMobs.Count() * delta;
            GetNode<ProgressBar>("%HealthBar").Value = health;
            
            if (health <= 0)
            {
                //Help.Debug();
                EmitSignal(SignalName.HealthDepleted);
            }
        }
    }

    //public override
}
