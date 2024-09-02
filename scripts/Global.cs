using Godot;
using System;

public partial class Global : Node
{
	[Signal]
	public delegate void MySimpleSignalEventHandler();
	
	
	public int score = 11;
	
	public void ScoreAdd(int score){
		this.score += score;
		GD.Print("Score: " + this.score);
		EmitSignal(nameof(MySimpleSignalEventHandler));
	}
	
	public void ScoreDelete(int score){
		if ( this.score > 0 )
			this.score -= score;
		GD.Print("Score: " + this.score);
	}
	
	
}
