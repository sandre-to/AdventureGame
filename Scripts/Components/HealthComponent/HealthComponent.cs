using Godot;
using System;

namespace Scripts.Components;
public partial class HealthComponent : BaseComponent
{
    [Signal]
    public delegate void DestroyedEventHandler();

    [Export]
    public float Health;

    public override void _Ready()
    {
        GD.Print(Health);
    }

    public void TakeDamage(float amount)
    {
        Health = Mathf.Max(Health - amount, 0);
        
        if (IsDestroyed())
        {
            EmitSignal(SignalName.Destroyed);
        }
    }

    public bool IsDestroyed()
    {
        return Health <= 0;
    }
}