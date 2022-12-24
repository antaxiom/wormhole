using Godot;
using System;

public partial class Player2D : CharacterBody2D
{
    private const float Speed = 500;
    private const float World3DSpeedMultiplier = 1f / 10_000f; // 0.3f

    [Export]
    private NodePath _torusPath;

    private Node3D _torus;

    public override void _Ready()
    {
        _torus = GetNode<Node3D>(_torusPath);
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
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
        var rotation = _torus.Rotation;
        rotation.y -= velocity.x * World3DSpeedMultiplier;
        _torus.Rotation = rotation;
        
        // TODO: Loop around the 2D world in 360 space
    }
}