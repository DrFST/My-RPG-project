using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;


    [SerializeField] private int facingDir = 1;
    [SerializeField] private bool facingRight = true;
    public int FacingDir => facingDir;
    public bool FacingRight => facingRight;

    [Header("face info")]
    public int fachingDir = 1;
    public bool fachingRight = true;

    [Header("Collision info")]
    [SerializeField] protected UnityEngine.Transform groundCheck;
    [SerializeField] protected UnityEngine.Transform wallCheck;
    [SerializeField] protected float groundCheckDis;
    [SerializeField] protected float wallCheckDis;
    [SerializeField] protected LayerMask whatIsGround;
    protected virtual void Awake()
    {
 
    }
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }


    protected virtual void Update()
    {
        isGroundCheck();

    }


    //检查是否处于接地状态
    public virtual bool isGroundCheck()
    {
        return Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDis, whatIsGround);

    }

    //检查是否处于爬墙状态
    public virtual bool isWallSlideCheck()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * fachingDir, wallCheckDis, whatIsGround);

    }

    //转向
    public  virtual void Flip()
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
    protected virtual void OnDrawGizmos()
    {

        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDis));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDis, wallCheck.position.y));

    }
}



