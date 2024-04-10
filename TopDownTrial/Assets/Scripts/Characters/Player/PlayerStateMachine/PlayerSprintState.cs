using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintState : PlayerBaseState
{
    readonly int _runHash = Animator.StringToHash("SprintTree");
    public PlayerSprintState(PlayerController player) : base(player)
    {
        this._player = player;
    }

    public override void EnterState()
    {
        _player.Animator.Play(_runHash);
        _player.MoveSpeed = _player.RunSpeed;
    }

    public override void UpdateState(float delta)
    {
        Vector2 inputDir = new Vector2();
        inputDir = _player.MovementInput;
        inputDir = inputDir.normalized;

        Move(inputDir * _player.MoveSpeed, delta);
        UpdateAnimations();

        if (!_player.IsRunning)
        {
            _player.StateMachine.ChangeState(new PlayerMoveState(_player));
        }
    }
}
