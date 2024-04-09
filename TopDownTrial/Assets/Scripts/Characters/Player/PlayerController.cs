using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Components
    // this value will be modified through the function HandleMovementInput
    public Vector2 MovementInput { get; private set; }
    [field: SerializeField]
    public Animator Animator { get; private set; }
    [field: SerializeField]
    public Rigidbody2D RB2D { get; private set; }

    [field: SerializeField]
    public PlayerStateMachine StateMachine;
    #endregion

    #region Player Variables
    [field: SerializeField]
    public float MoveSpeed;
    [field: SerializeField]
    public float RunSpeed { get; private set; } = 3f;
    [field: SerializeField]
    public float WalkSpeed { get; private set; } = 1.5f;
    public bool IsRunning = false;
    #endregion

    #region Player Events
    // public event Action MoveEvent;
    #endregion

    void Awake()
    {
        Animator = GetComponent<Animator>();
        RB2D = GetComponent<Rigidbody2D>();
        StateMachine = new PlayerStateMachine();
    }

    void Start()
    {
        StateMachine.InitState(new PlayerIdleState(this));
    }

    void Update()
    {
        StateMachine.Update();
    }

    // This function will be called form the InputManager script.
    public void HandleMovement(Vector2 movement)
    {
        MovementInput = movement;
    }

    public void HandleRun()
    {
        IsRunning = !IsRunning;
    }
}
