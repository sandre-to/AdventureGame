using Godot;
using System;

namespace Scripts.Resources.Items;
[GlobalClass]
public partial class ItemStack(ItemResource item, int amount = 1) : Resource
{
    [Export]
    public ItemResource Item = item;

    [Export]
    public int Amount = amount;

    public override string ToString()
    {
        return $"{Item.Name}, {Amount}";
    }
}
