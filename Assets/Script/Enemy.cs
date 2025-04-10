using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : Entity
{
    public EnemyStateMachine StateMachine { get; private set; }
    //public EnemyIdolState IdolState { get; private set; }
    //public EnemyMoveState MoveState { get; private set; }

    //private float xInput;

    [Header("Move info")]
    [SerializeField] public float moveSpeed;

 

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new EnemyStateMachine();
       // IdolState = new EnemyIdolState(this, StateMachine, "Idol");
        //MoveState = new EnemyMoveState(this, StateMachine, "Move");
       
    }
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        StateMachine.currentState.update();
    }

    public void Movement(float _xVelocity, float _YVelocity)
    {

        rb.velocity = new Vector2(_xVelocity * moveSpeed, _YVelocity);

        FlipControllers(_xVelocity);
    }

}
