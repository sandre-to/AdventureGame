using Godot;
using Scripts.Components;
using System;

namespace Entities.Player;
public partial class Hitscan : RayCast3D
{   
    public float Damage = 1.5f;

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("LeftClick"))
        {
            if (IsColliding())
            {
                var collider = GetCollider() as HurtboxComponent;
                collider.TakeDamage(Damage);       
            }
            else
            {
                GD.Print("Missed shots!");
            }
        }
    }
}
