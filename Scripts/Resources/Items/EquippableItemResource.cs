using Godot;
using System;

namespace Scripts.Resources.Items;

[GlobalClass]
public partial class EquippableItemResource : ItemResource
{
    public enum WeaponType
    {
        Sword,
        SwordAndShield,
        Axe,
        Pickaxe,
        Shovel,
        Spear,
        Staff,
        Bow,
        Pistol
    }

    public enum WeaponTier
    {
        Low,
        Medium,
        High,
        Rare,
        Legendary
    }

    [Export]
    public WeaponType type;

    [Export]
    public WeaponTier tier;
}
