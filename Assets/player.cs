using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class player : Entity
{
    [Header("Move info")]
    [SerializeField] private float xInput;
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isMoving;

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

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update() 
    {

        base.Update();

        comboWindowCounter -= Time.deltaTime;
        dashiTime -= Time.deltaTime;


        Movement();
        CheckInput();
        AnimatorControllers();
        DashControllers();
        if (comboWindowCounter < 0)
        {
            attackCounter = 0;
        }

    }

    //»°œ˚π•ª˜
    public void attackOver()
    {
        isAttacking = false;
        attackCounter = attackCounter + 1;
        if (attackCounter>2 ) {
            attackCounter = 0;
        }

    }

    // ‰»Îº¸ºÏ≤‚
    private void CheckInput()
    {
        xInput = UnityEngine.Input.GetAxisRaw("Horizontal");



        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttacking = true;
           
            comboWindowCounter = comboTime;
        }


    }

    //≥Â¥Ã≈–∂®
    private  void DashControllers()
    {

        if (UnityEngine.Input.GetKeyDown(KeyCode.LeftShift) && dashiTime < 0 - dashCloudDown)
        {
            dashiTime = dashiDuration;
        }

    }

    //‘À∂Ø
    private void Movement()
    {
        if (dashiTime > 0)
        {
            rb.velocity = new Vector2(xInput * dashSpeed, 0);

        }
        else
        {

            rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
        }
    }

    //Ã¯‘æ
    private void jump()
    {
        if (isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    //∂Øª≠øÿ÷∆∆˜
    private void AnimatorControllers()
    {

        isMoving = rb.velocity.x != 0;

        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGround", isGround);
        anim.SetBool("isDashing", dashiTime > 0);
        anim.SetBool("isAttacking", isAttacking);
        anim.SetInteger("attackCounter", attackCounter);

    }
}