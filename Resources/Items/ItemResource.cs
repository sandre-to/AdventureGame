using Godot;
using System;

[GlobalClass]
public partial class ItemResource : Resource
{
    public enum ItemType
    {
        CraftingItem,
        EquippableItem,
        ConsumableItem
    }

    [Export]
    public ItemType itemType;

    [Export]
    public string Name;

    [Export(PropertyHint.MultilineText)]
    public string ItemDescription;

    [Export]
    public Texture2D image;
}
