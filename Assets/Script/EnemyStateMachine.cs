using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public EnemyState currentState { get; private set; }
    public void Initalize(EnemyState _EnemyState)
    {

        currentState = _EnemyState;
        currentState.Enter();

    }
    public void changeState(EnemyState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();

    }
}
