using GettingstartedwithGodot4;
using Godot;
using System;
using System.Linq;

public partial class gun : Area2D
{

    public override void _Ready()
    {
        base._Ready();
    }


    public override void _PhysicsProcess(double delta)
    {
        var enemiesInRange = GetOverlappingBodies();
        
        if (enemiesInRange.Any())
        {
            var target = enemiesInRange.First();
            LookAt(target.GlobalPosition);
        }
    }

    public void Shoot()
    {
        var newBullet = ResourceHelper.CreateResource<Node2D>("bullet");
        
        var gunNozzle = GetNode<Node2D>(new NodePath("WeaponPivot/Pistol/ShootingPoint"));
        newBullet.GlobalPosition = gunNozzle.GlobalPosition;
        newBullet.GlobalRotation = gunNozzle.GlobalRotation;


        gunNozzle.AddChild(newBullet);
    }

    //CalledByengine
    public void OnTimerTimeout()
    {
        GD.Print("timeout called");
        Shoot();
    }
}
