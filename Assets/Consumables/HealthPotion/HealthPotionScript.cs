using Godot;
using Scripts.InteractionSystem;
using Scripts.Resources.Items;
using System;

namespace Assets.Consumables;

public partial class HealthPotionScript : RigidBody3D
{
    [Export]
    private InteractionArea interactionArea;

    [Export]
    private ItemStack _itemData;

    public override void _Ready()
    {
        if (interactionArea == null)
        {
            GD.PushError("Missing interaction area.");
            return;  
        }

        interactionArea.Interacted += PickUp;
    }

    private void PickUp()
    {
        GD.Print($"Picked up {Name}.");
    }
}
