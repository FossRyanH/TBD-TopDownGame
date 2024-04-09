using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    PlayerController _player;
    PlayerInputs _inputActions;

    void Awake()
    {
        _player = GetComponent<PlayerController>();
    }

    void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new PlayerInputs();
            _inputActions.PlayerMovement.Move.performed += i => _player.HandleMovement(i.ReadValue<Vector2>());
            _inputActions.PlayerActions.Sprint.performed += i => _player.HandleRun();
        }
        _inputActions.Enable();
    }
}
