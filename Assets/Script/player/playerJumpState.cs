using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJumpState : playerState
{
    public playerJumpState(player _player, playerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
        player.rb.velocity = new Vector2(player.rb.velocity.x, player.jumpForce);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void update()
    {
        base.update();
    
        if (player.rb.velocity.y <  0)
        {
            playerStateMachine.changeState(player.AirState);

        }

        if (xInput != 0)
        {
            player.SetVelocity(xInput * player.moveSpeed * .8f, player.rb.velocity.y);

        }
    }
}
