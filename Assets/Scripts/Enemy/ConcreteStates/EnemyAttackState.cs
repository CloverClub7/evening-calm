using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(EnemyClass enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {

    }

    public override void AnimationTriggerEvent(EnemyClass.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
        enemy.attackBaseInstance.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.attackBaseInstance.DoEnterLogic();
    }
    
    public override void ExitState()
    {
        base.ExitState();
        enemy.attackBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemy.attackBaseInstance.DoFrameUpdateLogic();
    }
    
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        enemy.attackBaseInstance.DoPhysicsLogic();
    }
}
