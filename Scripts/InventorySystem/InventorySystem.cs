using Godot;
using System;

namespace Scripts.InventorySystem;

[GlobalClass]
public partial class InventorySystem : Node
{
    public static InventorySystem Instance;

    [Export]    
    public Godot.Collections.Array<ItemResource> Items;

    public override void _Ready()
    {
        Instance = this;
    }

    public void AddItem(ItemResource item)
    {
        if (item.Type == ItemResource.ItemType.EquippableItem)
        {
            item.Amount = 1;
        }
        else
        {
            item.Amount += 1;
        }
        
        // Check if the item already exists in inventory.
        if (Items.Contains(item))
        {
            return;
        }

        Items.Add(item);
    }

    public void PrintItems()
    {
        foreach (ItemResource item in Items)
        {
            GD.Print(item);
        }
    }
}
