using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDashState : playerState
{
    public playerDashState(player _player, playerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }


    public override void Enter()
    {
        base.Enter();

        dashiTime = player.dashiDuration;

    }

    public override void Exit()
    {
        base.Exit();

        player.SetVelocity(0, player.rb.velocity.y);

    }

    public override void update()
    {

        base.update();

        player.SetVelocity(player.dashSpeed*player.dashDir, 0);
        if (dashiTime<0) {

            playerStateMachine.changeState(player.IdolState);

        }

    }
}
