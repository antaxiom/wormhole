using Godot;
using System;

public partial class Player2D : CharacterBody2D
{
	private const float Speed = 300.0f;

	[Export]
	private Node3D _torus;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "", "");
		if (direction != Vector2.Zero)
		{
			velocity.x = direction.x * Speed;
		}
		else
		{
			velocity.x = Mathf.MoveToward(Velocity.x, 0, Speed);
		}


		Velocity = velocity;
		MoveAndSlide();
		
		// Rotate 3D world
		
		// var rotation = _torus.Rotation;
		// rotation.y += velocity.x;
		// _torus.Rotation = rotation;
	}
}
