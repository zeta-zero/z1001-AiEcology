using Godot;
using System;

public partial class BaseGUI : Control
{
	[Export]
	private ButtonGroup LocalBtnGroup;
    [Export]
    private ButtonMenu LocalBtnMenu;
    // Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        if(LocalBtnGroup != null) {
            LocalBtnGroup.ButtonEvent += LocalBtnGroup_ButtonEvent;
        }
        if (LocalBtnMenu != null) {
            LocalBtnMenu.ButtonEvent += LocalBtnMenu_ButtonEvent; ;
        }
    }

    private void LocalBtnMenu_ButtonEvent(ButtonMenu.ButtonType _args)
    {
        switch (_args) {
            case ButtonMenu.ButtonType.Continue: {
                if (LocalBtnMenu.Visible == true) {
                    LocalBtnMenu.Visible = false;
                }
                LocalBtnGroup.Renew();
            }
            break;
            case ButtonMenu.ButtonType.Exit: {
                GetTree().Quit();
            }break;
            default:break;
        }
    }

    private void LocalBtnGroup_ButtonEvent(ButtonGroup.ButtonType _args)
    {
        switch(_args) {
            case ButtonGroup.ButtonType.SettingBtn: {
                if(LocalBtnMenu.Visible == false) {
                    LocalBtnMenu.Visible = true;
                }
                LocalBtnGroup.Stop();
            }
            break;
            case ButtonGroup.ButtonType.StopBtn: {
                
            }break;
            default:break;
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
