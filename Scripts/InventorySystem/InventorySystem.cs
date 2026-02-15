using Godot;
using Scripts.Resources.Items;
using System;

namespace Scripts.InventorySystem;

[GlobalClass]
public partial class InventorySystem : Node
{
    public static InventorySystem Instance;

    [Export]    
    public Godot.Collections.Array<ItemStack> Items = [];

    [Export]
    public Godot.Collections.Array<EquippableItemResource> Weapons = [];

    public override void _Ready()
    {
        Instance = this;
    }

    public void AddItem(ItemStack item, int amount)
    {
        
    }

    public void AddWeapon(EquippableItemResource weapon)
    {   
        // Every weapon data is unique. Does not need to duplicate weapon resources.
        if (Weapons.Contains(weapon))
        {
            GD.Print($"{weapon.Name} already exists.");
            return;
        }
        Weapons.Add(weapon);
    }

    public void PrintItems()
    {
        foreach (ItemStack item in Items)
        {
            GD.Print(item);
        }
    }

    public void PrintWeapons()
    {
        foreach (EquippableItemResource weapon in Weapons)
        {
            GD.Print(weapon);
        }
    }

    public void GetConsumableItem(ConsumableItemResource.ConsumableType consType)
    {
        
    }
}
