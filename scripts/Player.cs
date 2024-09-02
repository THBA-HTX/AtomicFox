using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 200.0f;
	public const float JumpVelocity = -340.0f;

	AnimatedSprite2D aniSprite;
	
	public override void _Ready(){
		aniSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Hente input retning -1, 0, 1
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		
		// Flip sprite
		if ( direction.X > 0 ){
			aniSprite.FlipH = false;
		} else if ( direction.X < 0 ){
			aniSprite.FlipH = true;
		}
		
		// Hvilken animation skal afspilles ud fra retning, og underlag
		if ( IsOnFloor() ){
			if ( direction.X == 0 ) {
				aniSprite.Play("idle");
			} else {
				aniSprite.Play("walk");
			}
		} else {
			aniSprite.Play("jump");
		}
		
		// foretager bevægelse
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
