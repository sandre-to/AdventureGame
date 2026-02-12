using Godot;
using System;

public partial class PlayerScript : CharacterBody3D
{
    [Export]
    private float _moveSpeed = 2f;

    private void Movement()
    {
        var direction = Input.GetVector("left", "right", "forward", "back");
        
        Velocity = Velocity with 
            { 
                X = direction.X, 
                Y = 0, 
                Z = direction.Y 
            } * _moveSpeed;
        
        MoveAndSlide();
    }

    public override void _PhysicsProcess(double delta)
    {
        Movement();
    }

}