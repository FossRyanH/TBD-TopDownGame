using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    // Access the current state the charcater or object in question is in.
    // Get publically (from any script) asnd set privately from within the statemachine or event in question.
    public IState CurrentState { get; private set; }

    // Notifies other objects of the state change.
    public event Action<IState> _stateChanged;

    public void InitializeState(IState state)
    {
        CurrentState = state;
        state.EnterState();

        // Sends out the notification that the state has changed.
        _stateChanged?.Invoke(state);
    }

    public void ChangeState(IState nextState)
    {
        CurrentState.ExitState();
        CurrentState = nextState;
        nextState.EnterState();

        _stateChanged?.Invoke(nextState);
    }
}
