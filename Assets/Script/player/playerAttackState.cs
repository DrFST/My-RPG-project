using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class playerAttackState : playerState
{
    private int attackCounter = 0;
    private float lastComboTime ;
    private float comboWindow = 2;

    private float attackCooldown = 0.3f; // ����0.3�������ٴι���

    public playerAttackState(player _player, playerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if (attackCounter>2 || Time.time>lastComboTime+ comboWindow) {
            attackCounter = 0;
        }
        player.anim.SetInteger("attackCounter", attackCounter);
    }

    public override void Exit()
    {
        base.Exit();
        attackCounter++;
        lastComboTime = Time.time;

        player.SetVelocity(0, player.rb.velocity.y);
    }

    public override void update()
    {

        base.update();

        // �����޸������ڶ�������ҵ�ǰ���ǹ���״̬ʱ�л���Idle
        if (triggerCalled && playerStateMachine.currentState == this)
        {
            playerStateMachine.changeState(player.IdolState);
        }

 /*       if (triggerCalled ) { 
            playerStateMachine.changeState(player.IdolState);
        }*/
    }
    public bool CanAttack()
    {
        return Time.time > lastComboTime + attackCooldown
               && playerStateMachine.currentState != this;
    }


}
