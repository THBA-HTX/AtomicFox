using Godot;
using System;

public partial class Hud : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	public Label scoreLabel;
	
	public override void _Ready()
	{
		
		//GetNode<Global>("/root/Global").Connect("MySimpleSignalEventHandler", this, nameof(_OnScoreChange));

		scoreLabel = GetNode<Label>("GameUI/Score");
		GD.Print("ScoreLabel: " +  scoreLabel );
		
		// this.updateScore();
	}
	
	
	public void _OnScoreChange()
	{
		GD.Print("update..");
		GD.Print("Score: " + GetNode<Global>("/root/Global").score );
		GD.Print("OK");
		this.scoreLabel.Text = ""+GetNode<Global>("/root/Global").score;
	}


}
