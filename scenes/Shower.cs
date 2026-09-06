using Godot;
using System;

public partial class Shower : Node2D
{

    public AnimationPlayer ShowerAnimation;

    private bool _isPlayerDetected;

    public override void _Ready()
    {
        ShowerAnimation = GetNode<AnimationPlayer>("ShowerAnimation");
    }


    public override void _Process(double delta)
    {
        UseShower();
    }



    public void OnPlayerFinderBodyEntered(Node2D body)
    {
        if (body.IsInGroup("Player"))
        {
            _isPlayerDetected = true;
        }
    }

    public void OnPlayerFinderBodyExited(Node2D body)
    {
        if (body.IsInGroup("Player"))
        {
            _isPlayerDetected = false;
        }
    }

    public void UseShower()
    {
        if (_isPlayerDetected)
        {
            ShowerAnimation.Play("Active");
        }
        else
        {
            ShowerAnimation.Play("Idle");
        }
    }
}
