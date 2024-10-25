using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerState 
{

    protected player player;
    protected playerStateMachine playerStateMachine;
    private string animBoolName;


    public playerState(player _player ,playerStateMachine _playerStateMachine ,string _animBoolName) { 
    
        this.player = _player;
        this.playerStateMachine = _playerStateMachine;
        this.animBoolName = _animBoolName;

    }

    public virtual void Enter() {



    }
    public virtual void updata()
    {



    }
    public virtual void Exit()
    {



    }

}
