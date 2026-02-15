using Godot;
using System;

namespace Scripts.Resources.Items;
[GlobalClass]
public partial class ItemStack : Resource
{
    [Export]
    public ItemResource Item;

    [Export]
    public int Amount;
}
