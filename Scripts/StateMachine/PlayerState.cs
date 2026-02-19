using Godot;
using System;
using Scripts.StateMachine;
using Entities.Player;
using System.Diagnostics;

namespace Scripts.StateMachine;

[GlobalClass]
public abstract partial class PlayerState : State
{
    protected PlayerScript Player;

    public override void _Ready()
    {
        Player = GetOwner<PlayerScript>();
    }
}
