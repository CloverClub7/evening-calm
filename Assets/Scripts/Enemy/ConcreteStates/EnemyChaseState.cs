using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(EnemyClass enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {

    }

    public override void AnimationTriggerEvent(EnemyClass.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
        enemy.chaseBaseInstance.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.chaseBaseInstance.DoEnterLogic();

        Debug.Log("Slime entered chase state.");
    }
    
    public override void ExitState()
    {
        base.ExitState();
        enemy.chaseBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemy.chaseBaseInstance.DoFrameUpdateLogic();
    }
    
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        enemy.chaseBaseInstance.DoPhysicsLogic();
    }
}
