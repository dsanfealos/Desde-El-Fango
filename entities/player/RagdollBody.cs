using Godot;
using System;

public partial class RagdollBody : RigidBody2D
{
    
    public Area2D MouseFindable;
    public RigidBody2D LeftArm;
    public RigidBody2D RightArm;
    public RigidBody2D Legs;
    private bool _isGrabbable = false;
    private bool _isGrabbed = false;
    [Export] public float DragSpeed = 5.0f;


    public override void _Ready()
    {
        LeftArm = GetParent().GetNode<RigidBody2D>("RagdollLeftArm");
        RightArm = GetParent().GetNode<RigidBody2D>("RagdollRightArm");
        Legs = GetParent().GetNode<RigidBody2D>("RagdollLegs");
    }

    public override void _Process(double delta)
    {        
        var mousePosition = GetGlobalMousePosition();
        Vector2 targetVelocity = (mousePosition - GlobalPosition) * DragSpeed;

        if (_isGrabbed)
        {
            LinearVelocity = targetVelocity;
            AngularVelocity = 0;
            LeftArm.AngularVelocity = AngularVelocity;
            RightArm.AngularVelocity = AngularVelocity;
            Legs.AngularVelocity = AngularVelocity;
        }else if (Input.IsActionJustReleased("click"))
        {
            LinearVelocity *= 0.2f; 

            LeftArm.LinearVelocity = LinearVelocity;
            RightArm.LinearVelocity = LinearVelocity;
            Legs.LinearVelocity = LinearVelocity;
        }
    }

    public void OnMouseFinderMouseEntered()
    {
        _isGrabbable = true;
    }

    public void OnMouseFinderMouseExited()
    {
        _isGrabbable = false;
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton btn &&
            btn.ButtonIndex == MouseButton.Left)
        {
            if (btn.IsPressed() && _isGrabbable)
            {
                _isGrabbed = true;                
                
            }else
            {
                _isGrabbed = false;
            }
        }
    }
}
