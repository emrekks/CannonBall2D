using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class StateMachine : MonoBehaviour
{ 
   public State currentState;
    void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            SwitchToTheNextState(nextState);
        }
    }

    private void SwitchToTheNextState(State nextState)
    {
        currentState = nextState;
    }
}
