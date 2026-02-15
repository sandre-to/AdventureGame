using Godot;
using System;
namespace Scripts.Resources.Items;

[GlobalClass]
public partial class ConsumableItemResource : ItemResource
{
    public enum ConsumableType
    {
        HealthPotion,
        StaminaPotion
    }

    public enum ConsumableTier
    {
        Low,
        Medium,
        High,
        Rare,
        Legendary
    }
    
    [Export]
    public ConsumableType type;

    [Export]
    public ConsumableTier tier;
}
