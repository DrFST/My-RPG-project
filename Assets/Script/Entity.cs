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


    //����Ƿ��ڽӵ�״̬
    public virtual bool isGroundCheck()
    {
        return Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDis, whatIsGround);

    }

    //����Ƿ�����ǽ״̬
    public virtual bool isWallSlideCheck()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * fachingDir, wallCheckDis, whatIsGround);

    }

    //ת��
    public  virtual void Flip()
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
    protected virtual void OnDrawGizmos()
    {

        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDis));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDis, wallCheck.position.y));

    }
}



