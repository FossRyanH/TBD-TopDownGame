using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMoveState : PlayerBaseState
{
    #region Animation Variables
    readonly int _moveHash = Animator.StringToHash("LocomotionTree");
    #endregion
    public PlayerMoveState(PlayerController player) : base(player)
    {
        this._player = player;
    }

    public override void EnterState()
    {
        _player.Animator.Play(_moveHash);
        _player.MoveSpeed = _player.WalkSpeed;
        _player.SprintEvent += HandleRun;
    }

    public override void UpdateState(float delta)
    {
        Vector2 inputDir = new Vector2();
        inputDir = _player.MovementInput;
        inputDir = inputDir.normalized;

        Move(inputDir * _player.MoveSpeed, delta);

        UpdateAnimations();

        if (_player.MovementInput == Vector2.zero)
        {
            _player.StateMachine.ChangeState(new PlayerIdleState(_player));
            _player.MoveSpeed = 0f;
        }
    }

    public override void ExitState()
    {
        _player.SprintEvent -= HandleRun;
    }

    void HandleRun()
    {
        _player.StateMachine.ChangeState(new PlayerSprintState(_player));
    }
}
