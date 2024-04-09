using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMoveState : PlayerBaseState
{
    #region Animation Variables
    readonly int _locomotionHash = Animator.StringToHash("LocomotionTree");
    readonly int _sprintingHash = Animator.StringToHash("SprintTree");
    readonly int _yMovement = Animator.StringToHash("YMovement");
    readonly int _xMovement = Animator.StringToHash("XMovement");
    #endregion

    public PlayerMoveState(PlayerController player) : base(player)
    {
        this._player = player;
    }

    public override void EnterState()
    {
        _player.Animator.Play(_locomotionHash);
    }

    public override void UpdateState(float delta)
    {
        Move(_player.MovementInput * _player.MoveSpeed, delta);

        UpdateAnimations();

        if (_player.MovementInput == Vector2.zero)
        {
            _player.StateMachine.ChangeState(new PlayerIdleState(_player));
            _player.MoveSpeed = 0f;
        }
    }

    // Update Animations as the player moves
    // TODO: Add speed updates later.
    void UpdateAnimations()
    {
        // Set the anim tree and speed.
        if (_player.IsRunning)
        {
            _player.MoveSpeed = _player.RunSpeed;
            _player.Animator.Play(_sprintingHash);
        }
        else
        {
            _player.MoveSpeed = _player.WalkSpeed;
            _player.Animator.Play(_locomotionHash);
        }
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
