using GettingstartedwithGodot4;
using Godot;

public partial class monster : CharacterBody2D
{

    Node2D player;

    private int Health = 2;
    public override void _Ready()
    {
        player = GetNode<Node2D>(new NodePath("/root/Game/Player"));
        //Help.Debug();

        GetNode<Node2D>(new NodePath("Slime")).Call("play_walk");
        //GetNode<Node2D>(new NodePath("/root/Game/Monster")).Call("play_walk");
    }

    public override void _PhysicsProcess(double delta)
    {
        var direction = GlobalPosition.DirectionTo(player.GlobalPosition);

        Velocity = direction * 300;
        MoveAndSlide();
    }

    public void TakeDamage()
    {
        Health--;
        GetNode<Node2D>(new NodePath("Slime")).Call("play_hurt");

        if (Health <= 0)
        {
            QueueFree();

            var smoke = ResourceHelper.CreateResource<Node2D>("smoke_explosion/smoke_explosion");
            GetParent().AddChild(smoke);
            smoke.GlobalPosition = GlobalPosition;

            //Help.Debug();
           
            //AddChild(smoke);

            //
        }
    }
}
