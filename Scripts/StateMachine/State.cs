using Godot;
using System;

namespace Scripts.StateMachine;

[GlobalClass]
public abstract partial class State : Node
{
    [Signal]
    public delegate void TransitionedEventHandler(State state, string newState);
    public void Enter() {}
    public void Exit() {}
    public void HandleInput(InputEvent _event) {}
    public void Update(double _delta) {}
    public void PhysicsUpdate(double _delta) {}
}
