using Godot;
using System;
using Scripts.StateMachine;
using Entities.Player;
using System.Diagnostics;

namespace Scripts.StateMachine;
public partial class PlayerState : State
{
    protected PlayerScript Player;

    public override void _Ready()
    {
        Player = Owner as PlayerScript;
        Debug.Assert(Player != null, "Owner has to be a player node.");
    }
}
