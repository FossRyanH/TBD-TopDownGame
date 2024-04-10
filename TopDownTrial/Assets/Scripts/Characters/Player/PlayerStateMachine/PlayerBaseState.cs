using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : IState
{
    protected PlayerController _player;

    #region Animation Variables
    readonly int _yMovement = Animator.StringToHash("YMovement");
    readonly int _xMovement = Animator.StringToHash("XMovement");
    #endregion

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

    protected void UpdateAnimations()
    {
        // Set player facing direction
        if (Mathf.Abs(_player.MovementInput.y) > 0.1f)
        {
            _player.Animator.SetFloat(_yMovement, _player.MovementInput.y);
        }
        else if (Mathf.Abs(_player.MovementInput.x) > 0.1f)
        {
            _player.Animator.SetFloat(_xMovement, _player.MovementInput.x);
        }
    }
}
