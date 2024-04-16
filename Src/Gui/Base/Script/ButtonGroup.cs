using Godot;
using System;

public partial class ButtonGroup : Control {
	[Export]
	private Godot.Button SettingButton;
	[Export]
	private Godot.Button Rate1Button;
	[Export]
	private Godot.Button Rate5Button;
	[Export]
	private Godot.Button RateMaxButton;
	[Export]
	private Godot.Button StopButton;

	public enum ButtonType {
		SettingBtn = 0x01,
		Rate1Btn,
		Rate5Btn,
		RateMaxBtn,
		StopBtn
	}

    private bool[] BtnStaList = new bool[4];

	public delegate void ButtonAction(ButtonType _args);
	public event ButtonAction ButtonEvent;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(SettingButton != null) {
            SettingButton.Pressed += SettingButton_Pressed;
        }
        if (Rate1Button != null) {
            Rate1Button.Pressed += Rate1Button_Pressed; ;
        }
        if (Rate5Button != null) {
            Rate5Button.Pressed += Rate5Button_Pressed; ;
        }
        if (RateMaxButton != null) {
            RateMaxButton.Pressed += RateMaxButton_Pressed; ;
        }
        if (StopButton != null) {
            StopButton.Pressed += StopButton_Pressed; ;
        }
    }

    private void SettingButton_Pressed()
    {
		ButtonEvent?.Invoke(ButtonType.SettingBtn);
    }

    private void Rate1Button_Pressed()
    {
        ButtonEvent?.Invoke(ButtonType.Rate1Btn);
    }

    private void Rate5Button_Pressed()
    {
        ButtonEvent?.Invoke(ButtonType.Rate5Btn);
    }

    private void RateMaxButton_Pressed()
    {
        ButtonEvent?.Invoke(ButtonType.RateMaxBtn);
    }

    private void StopButton_Pressed()
    {
        ButtonEvent?.Invoke(ButtonType.StopBtn);
    }


    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}

    public void Stop()
    {
        if (Rate1Button != null) {
            BtnStaList[0] = Rate1Button.ButtonPressed;
        }
        if (Rate5Button != null) {
            BtnStaList[1] = Rate5Button.ButtonPressed;
        }
        if (RateMaxButton != null) {
            BtnStaList[2] = RateMaxButton.ButtonPressed;
        }
        if (StopButton != null) {
            BtnStaList[3] = StopButton.ButtonPressed;
        }
        StopButton.ButtonPressed = true;
    }

    public void Renew()
    {
        if (Rate1Button != null) {
            Rate1Button.ButtonPressed = BtnStaList[0];
        }
        if (Rate5Button != null) {
            Rate5Button.ButtonPressed = BtnStaList[1];
        }
        if (RateMaxButton != null) {
            RateMaxButton.ButtonPressed = BtnStaList[2];
        }
        if (StopButton != null) {
            StopButton.ButtonPressed = BtnStaList[3];
        }
    }

}
