using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStateMachine StateMachine { get; private set; }
    public EnemyIdolState IdolState { get; private set; }
    public EnemyMoveState MoveState { get; private set; }

    public Rigidbody2D rb;
    public Animator anim;
    private float xInput;

    [Header("Move info")]
    [SerializeField] public float moveSpeed;

    [Header("face info")]
    [SerializeField] public int fachingDir = 1;
    [SerializeField] protected bool fachingRight = true;

    private void Awake()
    {
        StateMachine = new EnemyStateMachine();
        IdolState = new EnemyIdolState(this, StateMachine, "Idol");
        MoveState = new EnemyMoveState(this, StateMachine, "Move");
       
    }
        void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        StateMachine.Initalize(IdolState);
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.currentState.update();
    }

    public void Movement(float _xVelocity, float _YVelocity)
    {

        rb.velocity = new Vector2(_xVelocity * moveSpeed, _YVelocity);

        FlipControllers(_xVelocity);
    }

    //面相控制
    protected virtual void FlipControllers(float _x)
    {
        if (_x > 0 && !fachingRight)
            Flip();
        else if (_x < 0 && fachingRight)
            Flip();
    }

    //转向
    public virtual void Flip()
    {
        fachingDir = fachingDir * -1;
        fachingRight = !fachingRight;
        transform.Rotate(0, 180, 0);
    }


}
