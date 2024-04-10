using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    readonly int _idleHash = Animator.StringToHash("IdleTree");
    public PlayerIdleState(PlayerController player) : base(player)
    {
        this._player = player;
    }

    public override void EnterState()
    {
        _player.Animator.Play(_idleHash);
        _player.MoveSpeed = 0f;
    }

    public override void UpdateState(float delta)
    {
        Move(delta);

        if (_player.MovementInput != Vector2.zero)
        {
            _player.StateMachine.ChangeState(new PlayerMoveState(_player));
        }
    }
}
