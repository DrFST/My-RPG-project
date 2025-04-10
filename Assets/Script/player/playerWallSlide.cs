using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWallSlide : playerState
{

    public playerWallSlide(player _player, playerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
         
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void update()
    {
        base.update();

        if (xInput != 0 && player.fachingDir != xInput )
        {
            playerStateMachine.changeState(player.IdolState);
            player.rb.velocity = new Vector2(0, player.rb.velocity.y * .7f);
            return;
        }
        if (player.isGroundCheck() || !player.isWallSlideCheck()) {
            playerStateMachine.changeState(player.IdolState);
            player.rb.velocity = new Vector2(0, player.rb.velocity.y * .7f);
            return;
        }

        // 蹬墙跳
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && Time.time > player.lastwallJumpTime + player.wallJumpCooldown)
        {
            
            //記錄蹬牆跳時間
            player.lastwallJumpTime = Time.time;
            // 逐渐减少y方向上的力(暫定)
            player.wallJumpForce.y = Mathf.Lerp(player.wallJumpForce.y, 5f, 0.2f); 
            // 蹬牆跳反向力設置
            player.rb.velocity = new Vector2(-player.fachingDir * player.wallJumpForce.x, player.wallJumpForce.y);
            // 设置面向
            player.Flip();
            playerStateMachine.changeState(player.JumpState);
            
            return;
            }
        }
}
 
