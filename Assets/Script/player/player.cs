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
    public playerDashState DashState { get; private set; }

    public playerWallSlide WallSlide { get; private set; }

    public playerAttackState AttackState { get; private set; }

    public float dashDir { get; private set; }

    public Rigidbody2D rb;
    public Animator anim;
    private float xInput;

    [Header("Move info")]
    [SerializeField] public float jumpForce;
    [SerializeField] public float moveSpeed;

    [Header("dash info")]
    public float dashiDuration;
    public float dashSpeed;
    [SerializeField] private float dashCoolDown ;
    private float dashTimer;

   
    [Header("Collision info")]
    [SerializeField] private UnityEngine.Transform groundCheck;
    [SerializeField] private UnityEngine.Transform wallCheck;
    [SerializeField] protected float groundCheckDis;
    [SerializeField] protected float wallCheckDis;
    [SerializeField] protected LayerMask whatIsGround;

    [Header("wallJump")]
    //��ǽ��������
    [SerializeField] public Vector2 wallJumpForce = new Vector2(5f, 10f);
    //��ǽ����s�r�g
    [SerializeField] public float wallJumpCooldown = .5f;
    //ӛ���һ�ε�ǽ�r�g
    [SerializeField] public float lastwallJumpTime;

    [Header("face info")]
    [SerializeField] public int fachingDir = 1;
    [SerializeField] protected bool fachingRight = true;

   

    private  void Awake()
    {

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
    protected  void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        StateMachine.Initalize(IdolState);

    }

    // Update is called once per frame
    protected  void Update() 
    {
        StateMachine.currentState.update();

        isGroundCheck();
        DashControllers();

    }

    //���������ж�
    //C# �ļ�д Lambda ���ʽд��
    public void AnimationTrigger() => StateMachine.currentState.AnimationFinishTrigger();
    // �ȼ��ڡ�
 /*   public void AnimationTrigger()
    {
        StateMachine.currentState.AnimationFinishTrigger();
    }*/

    //����ж�
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
    //���
    public void SetVelocity(float _xVelocity, float _YVelocity)
    {
        rb.velocity = new Vector2(_xVelocity , _YVelocity);

        FlipControllers(_xVelocity);

    }

    //�˶�
    public void Movement(float _xVelocity, float _YVelocity)
    {
       
        rb.velocity = new Vector2(_xVelocity * moveSpeed, _YVelocity);

        FlipControllers(_xVelocity);
    }

    //����Ƿ��ڽӵ�״̬
    public bool isGroundCheck()
    {
        return Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDis, whatIsGround);
         
    }

    //����Ƿ�����ǽ״̬
    public bool isWallSlideCheck()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right*fachingDir, wallCheckDis, whatIsGround);

    }

    //ת��
    public virtual void Flip()
    {
        fachingDir = fachingDir * -1;
        fachingRight = !fachingRight;
        transform.Rotate(0, 180, 0);
    }
    //�������
    protected virtual void FlipControllers(float _x)
    {
        if (_x > 0 && !fachingRight)
            Flip();
        else if (_x < 0 && fachingRight)
            Flip();
    }

    //�������߼��
    protected  void OnDrawGizmos()
    {

        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDis));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDis, wallCheck.position.y ));

    }

}  