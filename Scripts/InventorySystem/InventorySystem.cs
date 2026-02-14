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
}
