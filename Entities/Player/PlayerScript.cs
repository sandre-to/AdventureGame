using Godot;
using Scripts.Components;
using System;

public partial class PlayerScript : CharacterBody3D
{
    [ExportCategory("Player properties")]
    [Export]
    private float _moveSpeed = 2f;

    [Export]
    private float _jumpForce = 3f;

    [Export]
    private float _mouseSensitivity = 0.005f;

    private float _gravity = -9.8f;

    [ExportCategory("Components")]
    [Export]
    private HealthComponent _healthComponent;

    [Export]
    private HurtboxComponent _hurtboxComponent;

    // References to child nodes.
    private Camera3D _cam;


    public override void _Ready()
    {   
        // Makes sure the mouse cursor is invincible during gameplay. 
        Input.MouseMode = Input.MouseModeEnum.Captured;

        _cam = GetNode<Camera3D>("Head");
        if (_cam == null)
        {
            GD.PushError("Missing camera node in player scene.");
            return;
        }

        _healthComponent.Destroyed += DoSomethingWhenDestroyed;
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("Escape"))
        {
            Input.MouseMode = Input.MouseModeEnum.Visible;
        }

        HandleCamera(@event);
    }


    public override void _PhysicsProcess(double delta)
    {
        Movement(delta);
    }

    private void HandleCamera(InputEvent @event)
    {
        if (@event is not InputEventMouseMotion eventMouseMotion) return;

        // When the mouse moves on the x-axis, rotate the camera in the y-axis direction.
        RotateY(-eventMouseMotion.Relative.X * _mouseSensitivity);
        _cam.RotateX(-eventMouseMotion.Relative.Y * _mouseSensitivity);
        var camRotation = _cam.Rotation;
        camRotation.X = Mathf.Clamp(camRotation.X, Mathf.DegToRad(-90), Mathf.DegToRad(90));
        _cam.Rotation = camRotation;
    }

    private void Movement(double delta)
    {
        var direction = Input.GetVector("Left", "Right", "Forward", "Back");
        
        // Retrieve the Velocity struct first, and modify it later in the method.
        var velocity = Velocity;
        velocity = Transform.Basis * new Vector3
            (
                direction.X * _moveSpeed, 
                velocity.Y, 
                direction.Y * _moveSpeed
            );

        // Apply constant gravity if the player is in the air.
        if (!IsOnFloor())
        {
            velocity.Y += _gravity * (float)delta;
        }

        // Jump input.
        if (Input.IsActionJustPressed("Jump") && IsOnFloor())
        {
            velocity.Y = _jumpForce;
        }

        // Apply all the changes back to Velocity
        Velocity = velocity;
        MoveAndSlide();
    }

    private void DoSomethingWhenDestroyed()
    {
        GD.Print("HELLO");
    }
}