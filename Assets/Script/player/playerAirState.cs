using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAirState : playerState
{
    public playerAirState(player _player, playerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
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
        //player.Movement(xInput, player.rb.velocity.y);

        if (player.isGroundCheck())
        {
            playerStateMachine.changeState(player.IdolState);
            player.SetVelocity(0, 0);
        }

        if (player.isWallSlideCheck() )
        {
                playerStateMachine.changeState(player.WallSlide);
                player.SetVelocity(0, 0);
        }

        if (xInput !=0)
        {
            player.SetVelocity(xInput * player.moveSpeed * .8f, player.rb.velocity.y);

        }

    }
}
