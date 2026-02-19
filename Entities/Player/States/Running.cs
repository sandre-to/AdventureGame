using Godot;
using System;
using Scripts.StateMachine;

namespace Entities.Player.States;
public partial class Running : PlayerState
{
    public override void Enter()
    {
        GD.Print("Entered running state!");
        Player.MoveSpeed = 5f;
    }

    public override void PhysicsUpdate(double _delta)
    {
        if (Player.Velocity.Length() <= 0f)
        {
            EmitSignal(SignalName.Transitioned, this, "Idle");
        }
    }

    public override void Exit()
    {
        GD.Print("Exiting running state!");
    }
}
