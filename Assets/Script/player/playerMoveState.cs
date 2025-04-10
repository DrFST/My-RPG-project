using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;


public class playerMoveState : playerGroundState
{


    public playerMoveState(player _player, playerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

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
       player.Movement(xInput, player.rb.velocity.y);

        if (xInput == 0)
        {
            playerStateMachine.changeState(player.IdolState);

        }
    }
}
