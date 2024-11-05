using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerState 
{

    protected player player;
    protected playerStateMachine playerStateMachine;
    protected Entity Entity;
    private string animBoolName;
    public float dashiTime;

    protected float xInput;
    public playerState(player _player ,playerStateMachine _playerStateMachine ,string _animBoolName) { 
    
        this.player = _player;
        this.playerStateMachine = _playerStateMachine;
        this.animBoolName = _animBoolName;

    }

    public virtual void Enter() {

        player.anim.SetBool(animBoolName, true);

        
    }
    public virtual void updata()
    {
        dashiTime -= Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");
        player.anim.SetFloat("yVelocity", player.rb.velocity.y);
    }
    public virtual void Exit()
    {

        player.anim.SetBool(animBoolName, false);


    }

}
