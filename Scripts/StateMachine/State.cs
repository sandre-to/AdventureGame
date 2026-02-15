using Godot;
using System;

namespace Scripts.StateMachine;

[GlobalClass]
public abstract partial class State : Node
{
    [Signal]
    protected delegate void TransitionedEventHandler();
    protected void Enter() {}
    protected void Exit() {}
    protected void Update() {}
    protected void PhysicsUpdate() {}
}
