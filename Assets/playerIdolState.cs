using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class playerIdolState : playerGroundState
{
    public playerIdolState(player _player, playerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
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

    public override void updata()
    {
        base.updata();
        if (xInput != 0)
        {

            playerStateMachine.changeState(player.MoveState);

        }
    }
}
