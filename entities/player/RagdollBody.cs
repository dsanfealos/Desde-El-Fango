using Godot;
using System;

public partial class RagdollBody : RigidBody2D
{
    
    private bool _isGrabbed = false;


    public override void _Ready()
    {
        
    }

    public override void _Process(double delta)
    {
        if (_isGrabbed)
        {
            var mousePosition = GetGlobalMousePosition();
            GlobalPosition = Lerp(GlobalPosition, mousePosition, 0.2f);
            return;
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton btn &&
            btn.ButtonIndex == MouseButton.Left)
        {
            if (@event.IsPressed())
            {
                _isGrabbed = true;                
            }else
            {
                _isGrabbed = false;
            }
        }
    }

    private Vector2 Lerp(Vector2 firstVector, Vector2 secondVector, float by)
    {
        float retX = Lerp(firstVector.X, secondVector.X, by);
        float retY = Lerp(firstVector.Y, secondVector.Y, by);
        return new Vector2(retX, retY);
    }

    float Lerp(float firstFloat, float secondFloat, float by)
    {
        return firstFloat * (1 - by) + secondFloat * by;
    }
}
