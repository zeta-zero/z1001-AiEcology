using Godot;
using System;
using static ButtonGroup;

public partial class ButtonMenu : Control
{
	[Export]
	private Godot.Button ContinueButton;
    [Export]
    private Godot.Button SettingButton;
    [Export]
    private Godot.Button ExitToMenuButton;
    [Export]
    private Godot.Button ExitButton;

    public enum ButtonType {
        Continue = 0x01,
        Setting,
        Exit2Menu,
        Exit,
    }

    public delegate void ButtonAction(ButtonType _args);
    public event ButtonAction ButtonEvent;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        if (ContinueButton != null) {
            ContinueButton.Pressed += ContinueButton_Pressed;
        }
        if (SettingButton != null) {
            SettingButton.Pressed += SettingButton_Pressed; 
        }
        if (ExitToMenuButton != null) {
            ExitToMenuButton.Pressed += ExitToMenuButton_Pressed; 
        }
        if (ExitButton != null) {
            ExitButton.Pressed += ExitButton_Pressed; 
        }
    }

    private void ExitButton_Pressed()
    {
        ButtonEvent?.Invoke(ButtonType.Exit);
    }

    private void ExitToMenuButton_Pressed()
    {
        ButtonEvent?.Invoke(ButtonType.Exit2Menu);
    }

    private void SettingButton_Pressed()
    {
        ButtonEvent?.Invoke(ButtonType.Setting);
    }

    private void ContinueButton_Pressed()
    {
        ButtonEvent?.Invoke(ButtonType.Continue);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
