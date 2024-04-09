using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : IState
{
    protected PlayerController _player;

    public PlayerBaseState(PlayerController player)
    {
        this._player = player;
    }

    // This is called every time the state in question is entered.
    public virtual void EnterState() {}
    // This is called every frame the game is running.
    public virtual void UpdateState(float delta) {}
    // Called when a specific state is being exited.
    public virtual void ExitState() {}

    protected void Move(Vector2 inputDir, float delta)
    {
        _player.RB2D.velocity = inputDir * delta;
    }

    protected void Move(float delta)
    {
        Move(Vector3.zero, delta);
    }
}
