using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{

    protected Enemy Enemy;
    protected EnemyStateMachine EnemyStateMachine;


    private string animBoolName;
    protected float xInput;
    protected bool triggerCalled;

    public EnemyState(Enemy _Enemy, EnemyStateMachine _EnemyStateMachine, string _animBoolName)
    {

        this.Enemy = _Enemy;
        this.EnemyStateMachine = _EnemyStateMachine;
        this.animBoolName = _animBoolName;

    }
    public virtual void Enter()
    {

        Enemy.anim.SetBool(animBoolName, true);
        triggerCalled = false;


    }

    public virtual void update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        Enemy.anim.SetFloat("yVelocity", Enemy.rb.velocity.y);
    }

    public virtual void Exit()
    {
        //triggerCalled = false;
        Enemy.anim.SetBool(animBoolName, false);


    }

    public virtual void AnimationFinishTrigger()
    {

        triggerCalled = true;
    }
}
