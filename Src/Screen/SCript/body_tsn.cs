using Godot;
using System;

public partial class body_tsn : Node2D
{
	[Export]
	private Godot.Camera2D LocalCamera2D;
	private bool DragMove;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public override void _Input(InputEvent @event)
    {
        if(@event is InputEventMouseButton mouseButton) {
			if(mouseButton.ButtonIndex == Godot.MouseButton.Right) {

			}
			else if(mouseButton.ButtonIndex == Godot.MouseButton.Left) {

			}
		}
    }
}
