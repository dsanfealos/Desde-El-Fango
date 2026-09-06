using Godot;
using System;

public partial class RagdollBody : RigidBody2D
{
    
    public Area2D MouseFindable;
    public RigidBody2D LeftArm;
    public RigidBody2D RightArm;
    public RigidBody2D LeftLeg;
    public RigidBody2D RightLeg;
    private bool _isGrabbable = false;
    private bool _isGrabbed = false;
    [Export] public float DragSpeed = 5.0f;


    public override void _Ready()
    {
        LeftArm = GetParent().GetNode<RigidBody2D>("RagdollLeftArm");
        RightArm = GetParent().GetNode<RigidBody2D>("RagdollRightArm");
        LeftLeg = GetParent().GetNode<RigidBody2D>("RagdollLeftLeg");
        RightLeg = GetParent().GetNode<RigidBody2D>("RagdollRightLeg");
    }

    public override void _Process(double delta)
    {        
        var mousePosition = GetGlobalMousePosition();
        Vector2 targetVelocity = (mousePosition - GlobalPosition) * DragSpeed;

        if (_isGrabbed)
        {
            LinearVelocity = targetVelocity;
        }else if (Input.IsActionJustReleased("click"))
        {
            
            
            //Sleeping = true;
            /*if (LinearVelocity.X > 500 || LinearVelocity.Y > 500)
            {
                LinearVelocity = new Vector2(500,500);
            }
            else if (LinearVelocity.X < -300)
            {
                LinearVelocity = new Vector2(-300, targetVelocity.Y);
            }
            else
            {
                LinearVelocity *= 0.2f;                
            }*/
            LinearVelocity *= 0.2f; 

            LeftArm.LinearVelocity = LinearVelocity;
            RightArm.LinearVelocity = LinearVelocity;
            LeftLeg.LinearVelocity = LinearVelocity;
            RightLeg.LinearVelocity = LinearVelocity;
            GD.Print("Linear: " + LinearVelocity);
            // LinearVelocity = targetVelocity;
            // ApplyImpulse(LinearVelocity * -1);
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
