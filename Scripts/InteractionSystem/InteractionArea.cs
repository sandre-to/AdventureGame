using Godot;
using System;

namespace Scripts.InteractionSystem;

[GlobalClass]
public partial class InteractionArea : Area3D
{
    public void Interact()
    {   
        GD.Print($"Interacting with object: {GetOwner<Node3D>().Name}");
    } 
}
