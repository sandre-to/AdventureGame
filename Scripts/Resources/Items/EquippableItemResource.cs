using Godot;
using System;

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
        Bow
    }

    public enum WeaponTier
    {
        Low,
        Medium,
        High,
        Legendary
    }

    [Export]
    public WeaponType type;

    [Export]
    public WeaponTier tier;
}
