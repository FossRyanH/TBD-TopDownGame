using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    #region Animation Variables
    readonly int _idleHash = Animator.StringToHash("IdleTree");
    readonly int _yMovement = Animator.StringToHash("YMovement");
    readonly int _xMovement = Animator.StringToHash("XMovement");
    #endregion

    public PlayerIdleState(PlayerController player) : base(player)
    {
        this._player = player;
    }

    public override void EnterState()
    {
        _player.Animator.Play(_idleHash);
        UpdateAnimations();
    }

    public override void UpdateState(float delta)
    {
        Move(delta);

        UpdateAnimations();

        if (_player.MovementInput != Vector2.zero)
        {
            _player.StateMachine.ChangeState(new PlayerMoveState(_player));
        }
    }

    void UpdateAnimations()
    {
        if (Mathf.Abs(_player.MovementInput.y)> 0.1f)
        {
            _player.Animator.SetFloat(_yMovement, _player.MovementInput.y);
        }
        else if (Mathf.Abs(_player.MovementInput.x) > 0.1f)
        {
            _player.Animator.SetFloat(_xMovement, _player.MovementInput.x);
        }
    }
}
