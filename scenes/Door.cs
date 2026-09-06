using Godot;
using System;

public partial class Door : Sprite2D
{

    private CollisionShape2D _closedCollision;

    public override void _Ready()
    {
        _closedCollision = GetNode<StaticBody2D>("ClosedDoor").GetNode<CollisionShape2D>("DoorCollision");
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("click"))
        {
            Frame = 1;
            _closedCollision.Disabled = true;
        }
        else
        {
            Frame = 0;
            _closedCollision.Disabled = false;
        }
    }


}
