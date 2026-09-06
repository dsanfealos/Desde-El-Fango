using Godot;
using System;

public partial class Camera2d : Camera2D
{
    
    public float Speed = 30.0f;


    public override void _Process(double delta)
    {

        if (Input.IsActionPressed("move_up"))
        {
            GlobalPosition += new Vector2(0, -Speed);
        }
        if (Input.IsActionPressed("move_down"))
        {
            GlobalPosition += new Vector2(0, Speed);
        }

        if (Input.IsActionPressed("move_left"))
        {
            GlobalPosition += new Vector2(-Speed, 0);
        }
        if (Input.IsActionPressed("move_right"))
        {
            GlobalPosition += new Vector2(Speed, 0);
        }
    }




}
