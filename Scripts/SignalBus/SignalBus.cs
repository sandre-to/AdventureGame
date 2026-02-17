using Godot;
using System;

namespace Scripts.SignalBus;
public partial class SignalBus : Node
{
	public static SignalBus Instance;

	// Declare signals in this script

    public override void _Ready()
    {
        Instance = this;
    }
}
