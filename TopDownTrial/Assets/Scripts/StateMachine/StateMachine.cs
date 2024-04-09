using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StateMachine
{
    // Access the current state the charcater or object in question is in.
    // Get publically (from any script) asnd set privately from within the statemachine or event in question.
    protected IState CurrentState;

    public void InitState(IState initialState)
    {
        if (CurrentState == null)
        {
            CurrentState = initialState;
            initialState?.EnterState();
        }
    }

    public void ChangeState(IState nextState)
    {
        CurrentState?.ExitState();
        CurrentState = nextState;
        nextState?.EnterState();
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.UpdateState(Time.deltaTime);
        }
    }
}
