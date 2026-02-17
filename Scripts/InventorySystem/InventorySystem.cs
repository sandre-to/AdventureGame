using System.Collections;
using Godot;
using Godot.Collections;
using Scripts.Resources.Items;

namespace Scripts.InventorySystem;

[GlobalClass]
public partial class InventorySystem : Node
{
    public static InventorySystem Instance;

    const int MaxStack = 99; 

    // I want to have three inventory categories:
    // 1. Holds all items that are craftable
    // 2. Holds all consumable items -> Potions, buffs etc.
    // 3. Holds all weapons (which are unique and do not stacks)

    [Export]    
    public Array<ItemStack> Items = [];

    [Export]
    public Array<ItemStack> Consumables = [];

    [Export]
    public Array<EquippableItemResource> Weapons = [];

    public override void _Ready()
    {
        Instance = this;
    }

    public void AddItem(ItemResource item, int amount)
    {
        if (item.Type != ItemResource.ItemType.CraftingItem) return;

        // Check if a stack of that type exists already
        foreach (ItemStack stack in Items)
        {   
            if (stack.Item.Type == item.Type)
            {
                stack.Amount += amount;
                return;
            }
        }

        var newStack = new ItemStack((ItemResource)item.Duplicate());
        Items.Add(newStack);
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

    public void AddConsumable(ConsumableItemResource consumable)
    {
        if (consumable.Type != ItemResource.ItemType.ConsumableItem) return;

        // Check if a stack of that type exists already
        foreach (ItemStack stack in Consumables)
        {   
            var stackItem = stack.Item as ConsumableItemResource;
            if (stackItem.type == consumable.type)
            {
                stack.Amount += 1;
                return;
            }
        }

        var newStack = new ItemStack((ItemResource)consumable.Duplicate());
        Consumables.Add(newStack);
    }

    public void PrintItems()
    {
        foreach (var item in Items)
        {
            GD.Print(item);
        }
    }

    public void PrintConsumables()
    {
        foreach (var item in Consumables)
        {
            GD.Print(item);
        }
    }

    public void PrintWeapons()
    {
        foreach (var weapon in Weapons)
        {
            GD.Print(weapon);
        }
    }

    public EquippableItemResource GetWeapon(EquippableItemResource.WeaponType weaponType)
    {
        foreach (EquippableItemResource weapon in Weapons)
        {
            if (weapon.type == weaponType)
            {
                return weapon;
            }
        }
        return null;
    }

    public ItemStack GetConsumableStack(ConsumableItemResource.ConsumableType consType)
    {
        foreach (ItemStack stack in Consumables)
        {
            var item = (ConsumableItemResource)stack.Item;
            if (item.type == consType)
            {
                return stack;
            }
        }
        return null;
    }

    public Array<ItemStack> GetItems()
    {
        return Items;
    }

    public Array<ItemStack> GetConsumables()
    {
        return Consumables;
    }

    public Array<EquippableItemResource> GetWeapons()
    {
        return Weapons; 
    }
}