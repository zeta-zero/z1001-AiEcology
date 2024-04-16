using Godot;
using Godot.Collections;
using System;
using System.Linq;

public partial class InfoGridContainer : GridContainer
{
	class InfoItem{
		public InfoItem(string _name,string _value,Texture2D _src = null)
		{
			Name = new Label { Text = _name };
			Value = new Label { Text = _value };
            Img = new ColorRect();
			Img.Color = Color.Color8(10,100,255);
			Img.CustomMinimumSize = new Vector2(16f,16f);
			Img.SizeFlagsHorizontal = SizeFlags.ShrinkCenter;
			Img.SizeFlagsVertical = SizeFlags.ShrinkCenter;
        }
		public Godot.ColorRect Img;
		public Godot.Label Name;
		public Godot.Label Value;
	}
	private System.Collections.Generic.Dictionary<string,InfoItem> InfoItemList = new System.Collections.Generic.Dictionary<string,InfoItem>();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(this.Columns != 3) {
			this.Columns = 3;
		}
		Add("CO2", 1000);

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public bool Add(string _name,UInt64 _val = 0)
	{
		bool res = false;
		if(InfoItemList.ContainsKey(_name) == false) {
			InfoItemList.Add(_name, new InfoItem(_name,_val.ToString()));
			this.AddChild(InfoItemList[_name].Img);
            this.AddChild(InfoItemList[_name].Name);
            this.AddChild(InfoItemList[_name].Value);
            res = true;
        }
		return res;
	}

	public bool Set(string _name,UInt64 _value)
	{
		bool res = false;
        if (InfoItemList.ContainsKey(_name)) {
            InfoItemList[_name].Value.Text = _value.ToString();
            res = true;
        }
        return res;
	}
}
