using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    // This is called every time the state in question is entered.
    public void EnterState() {}
    // This is called every frame the game is running.
    public void UpdateState(float delta) {}
    // Called when a specific state is being exited.
    public void ExitState() {}
}
