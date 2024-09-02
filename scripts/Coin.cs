using Godot;
using System;

public partial class Coin : Area2D
{
	AnimatedSprite2D ani;
	
	public override void _Ready()
	{
		ani = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		GD.Print( ani );
	}

	public void _OnBodyEntered(Node2D other)
	{
		GD.Print("Coin area was entered..");
		GetNode<Global>("/root/Global").ScoreAdd(100);
		//GetNode<CanvasLayer>("/root/HUD").updateScore();
		
		ani.Play("pickup");
	}
	
	public void _OnAnimationFinished()
	{
		GD.Print("Animation has finished.. bada bing, bada boom.");
		QueueFree();
	}
	
	

}
