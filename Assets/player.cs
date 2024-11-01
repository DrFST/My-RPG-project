using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class player : MonoBehaviour
{
    public playerStateMachine StateMachine { get; private set; }
    public playerIdolState IdolState { get; private set; }
    public playerMoveState MoveState { get; private set; }
    public playerJumpState JumpState { get; private set; }

    public playerAirState AirState { get; private set; }

    public playerGroundState GroundState { get; private set; }



    public Rigidbody2D rb;
    public Animator anim;
    private float xInput;
    //public Animator anim;

    [Header("Move info")]
    [SerializeField] public float jumpForce;
    [SerializeField] private float moveSpeed;

    [Header("dash info")]
    [SerializeField] private float dashiDuration;
    [SerializeField] private float dashiTime;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashCloudDown;

    [Header("attack info")]
    private bool isAttacking;
    private int attackCounter=0;
    private float comboWindowCounter;
    [SerializeField] private float comboTime=.3f;


    [Header("Collision info")]
    [SerializeField] private UnityEngine.Transform groundCheck;
    [SerializeField] private UnityEngine.Transform wallCheck;
    [SerializeField] protected float groundCheckDis;
    [SerializeField] protected float wallCheckDis;
    [SerializeField] protected LayerMask whatIsGround;



    protected int fachingDir = 1;
    protected bool fachingRight = true;

   

    private  void Awake()
    {

        StateMachine = new playerStateMachine();
        IdolState = new playerIdolState(this, StateMachine, "Idol");
        MoveState = new playerMoveState(this, StateMachine, "Move");
        JumpState = new playerJumpState(this, StateMachine, "Jump");
        AirState= new playerAirState(this, StateMachine, "Jump");
        GroundState = new playerGroundState(this, StateMachine, "isGround");
    }

    // Start is called before the first frame update
    protected  void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();


        StateMachine.Initalize(IdolState);

    }

    // Update is called once per frame
    protected  void Update() 
    {

        isGroundCheck();
        StateMachine. currentState.updata();
      

        comboWindowCounter -= Time.deltaTime;
        dashiTime -= Time.deltaTime;


        
        //CheckInput();
        //AnimatorControllers();
        //DashControllers();
        if (comboWindowCounter < 0)
        {
            attackCounter = 0;
        }

    }

    //取消攻击
    public void attackOver()
    {
        isAttacking = false;
        attackCounter = attackCounter + 1;
        if (attackCounter>2 ) {
            attackCounter = 0;
        }

    }

    //输入键检测
    //private void CheckInput()
    //{
    //    //xInput = UnityEngine.Input.GetAxisRaw("Horizontal");



    //    if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
    //    {
    //        jump();
    //    }
    //    if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
    //    {
    //        isAttacking = true;
           
    //        comboWindowCounter = comboTime;
    //    }


    //}

    //冲刺判定
    //private  void DashControllers()
    //{

    //    if (UnityEngine.Input.GetKeyDown(KeyCode.LeftShift) && dashiTime < 0 - dashCloudDown)
    //    {
    //        dashiTime = dashiDuration;
    //    }

    //}

    //运动
    public void Movement(float _xVelocity, float _YVelocity)
    {
        //if (dashiTime > 0)
        //{
        //    rb.velocity = new Vector2(_xVelocity * dashSpeed, 0);

        //}
        //else
        //{

        rb.velocity = new Vector2(_xVelocity * moveSpeed, _YVelocity);

        FlipControllers(_xVelocity);
        //}
    }

    //跳跃
    //private void jump(float _xVelocity, float _YVelocity)
    //{
    //    if (isGround)
    //    {
    //        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    //    }
    //}

    //动画控制器
    //private void AnimatorControllers()
    //{

    //    //isMoving = rb.velocity.x != 0;

    //    //anim.SetFloat("yVelocity", rb.velocity.y);
    //    //anim.SetBool("isMoving", isMoving);
    //    //anim.SetBool("isGround", isGround);
    //    //anim.SetBool("isDashing", dashiTime > 0);
    //    //anim.SetBool("isAttacking", isAttacking);
    //    //anim.SetInteger("attackCounter", attackCounter);

    //}


    //检查是否处于接地状态
    public bool isGroundCheck()
    {
        return Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDis, whatIsGround);
         
    }

    //转向
    protected virtual void Flip()
    {
        fachingDir = fachingDir * -1;
        fachingRight = !fachingRight;
        transform.Rotate(0, 180, 0);
    }
    //面相控制
    protected virtual void FlipControllers(float _x)
    {
        if (_x > 0 && !fachingRight)
            Flip();
        else if (_x < 0 && fachingRight)
            Flip();
    }

    //地面射线检测
    protected  void OnDrawGizmos()
    {
        //Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDis));

        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDis));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDis, wallCheck.position.y ));

    }
}  