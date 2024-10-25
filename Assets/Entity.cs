using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Animator anim;

    protected int fachingDir = 1;
    protected bool fachingRight = true;

    [SerializeField] protected float groundCheckDis;
    [SerializeField] protected LayerMask whatIsGround;
    protected bool isGround;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        isGroundCheck();
        FlipControllers();
    }

    //����Ƿ��ڽӵ�״̬
    protected virtual void isGroundCheck()
    {
        isGround = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDis, whatIsGround);
    }

    //ת��
    protected virtual void Flip()
    {
        fachingDir = fachingDir * -1;
        fachingRight = !fachingRight;
        transform.Rotate(0, 180, 0);
    }
    //�������
    protected virtual void FlipControllers()
    {
        if (rb.velocity.x > 0 && !fachingRight)
            Flip();
        else if (rb.velocity.x < 0 && fachingRight)
            Flip();
    }

    //�������߼��
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDis));
    }

}



