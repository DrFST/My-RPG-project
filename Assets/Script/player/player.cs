using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class player : Entity
{
    public playerStateMachine StateMachine { get; private set; }
    public playerIdolState IdolState { get; private set; }
    public playerMoveState MoveState { get; private set; }
    public playerJumpState JumpState { get; private set; }
    public playerAirState AirState { get; private set; }
    public playerGroundState GroundState { get; private set; }
    public playerDashState DashState { get; private set; }
    public playerWallSlide WallSlide { get; private set; }
    public playerAttackState AttackState { get; private set; }
    public float dashDir { get; private set; }

    [Header("Move info")]
    [SerializeField] public float jumpForce;
    [SerializeField] public float moveSpeed;

    [Header("dash info")]
    public float dashiDuration;
    public float dashSpeed;
    public float dashCoolDown ;
    public float dashTimer;

    [Header("wallJump")]
    //蹬墙跳反向力
    [SerializeField] public Vector2 wallJumpForce = new Vector2(5f, 10f);
    //蹬墙跳冷卻時間
    [SerializeField] public float wallJumpCooldown = .5f;
    //記錄上一次蹬墙時間
    [SerializeField] public float lastwallJumpTime;


    protected override void Awake()
    {
        base.Awake();

        StateMachine = new playerStateMachine();
        IdolState = new playerIdolState(this, StateMachine, "Idol");
        MoveState = new playerMoveState(this, StateMachine, "Move");
        JumpState = new playerJumpState(this, StateMachine, "Jump");
        AirState= new playerAirState(this, StateMachine, "Jump");
        GroundState = new playerGroundState(this, StateMachine, "isGround");
        DashState = new playerDashState(this, StateMachine, "Dash");
        WallSlide = new playerWallSlide(this, StateMachine, "WallSlide");
        AttackState = new playerAttackState(this, StateMachine, "Attack");
    }

    // Start is called before the first frame update
    protected override void Start()
    {
       base.Start();

        StateMachine.Initalize(IdolState);

    }

    // Update is called once per frame
    protected override void Update() 
    {
        base.Update();

        StateMachine.currentState.update();
        DashControllers();

    }

    //运动
    public void Movement(float _xVelocity, float _YVelocity)
    {

        rb.velocity = new Vector2(_xVelocity * moveSpeed, _YVelocity);

        FlipControllers(_xVelocity);
    }

    //攻击结束判断
    //C# 的简写 Lambda 表达式写法
    public void AnimationTrigger() => StateMachine.currentState.AnimationFinishTrigger();
    // 等价于↓
 /*   public void AnimationTrigger()
    {
        StateMachine.currentState.AnimationFinishTrigger();
    }*/

    //冲刺判定
    public void DashControllers()
    {
        dashTimer -= Time.deltaTime;

        if (UnityEngine.Input.GetKeyDown(KeyCode.LeftShift) && dashTimer<0)
        {
            dashTimer = dashCoolDown;
            dashDir = UnityEngine.Input.GetAxisRaw("Horizontal");

            if (dashDir==0 ) {
                dashDir = fachingDir;
            }

            StateMachine.changeState(DashState);
        }
    }
    //冲刺
    public void SetVelocity(float _xVelocity, float _YVelocity)
    {
        rb.velocity = new Vector2(_xVelocity , _YVelocity);

        FlipControllers(_xVelocity);

    }

}  