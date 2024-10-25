using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateMachine 
{

    public playerState currentState {get; private set; }
    public void Initalize(playerState _playerState) {

        currentState= _playerState;
        currentState.Enter();

    }
    public void changeState(playerState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();

    }

}
