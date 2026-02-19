using Godot;
using Scripts.StateMachine;
using System;

namespace Entities.Player.States;

public partial class Idle : PlayerState
{
    public override void Enter()
    {
        GD.Print("Entered idle state.");
        Player.Anim.Play("Idle");
        Player.MoveSpeed = 2f;
    }

    public override void Update(double _delta)
    {
        if (Input.IsActionJustPressed("Shift"))
        {
            EmitSignal(SignalName.Transitioned, this, "Running");
        }
    }


    public override void Exit()
    {
        GD.Print("Exiting idle state.");
    }
}
