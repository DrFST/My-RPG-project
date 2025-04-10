using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class playerGroundState : playerState
{
    public playerGroundState(player _player, playerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
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

        if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (player.AttackState.CanAttack()) // –¬‘ˆ¿‰»¥ºÏ≤È
            {
                playerStateMachine.changeState(player.AttackState);
            }
        }


        if (!player.isGroundCheck())
        {
            playerStateMachine.changeState(player.AirState);

        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Space)&& player.isGroundCheck())
            {
                playerStateMachine.changeState(player.JumpState);


            }

    }
}
