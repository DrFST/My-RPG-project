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

        // ��ǽ��
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && Time.time > player.lastwallJumpTime + player.wallJumpCooldown)
        {
            
            //ӛ䛵Š����r�g
            player.lastwallJumpTime = Time.time;
            // �𽥼���y�����ϵ���(����)
            player.wallJumpForce.y = Mathf.Lerp(player.wallJumpForce.y, 5f, 0.2f); 
            // �Š����������O��
            player.rb.velocity = new Vector2(-player.fachingDir * player.wallJumpForce.x, player.wallJumpForce.y);
            // ��������
            player.Flip();
            playerStateMachine.changeState(player.JumpState);
            
            return;
            }
        }
}
 
