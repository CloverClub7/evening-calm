using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(EnemyClass enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {

    }

    public override void AnimationTriggerEvent(EnemyClass.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
        enemy.idleBaseInstance.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.idleBaseInstance.DoEnterLogic();
    }
    
    public override void ExitState()
    {
        base.ExitState();
        enemy.idleBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemy.idleBaseInstance.DoFrameUpdateLogic();
    }
    
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        enemy.idleBaseInstance.DoPhysicsLogic();
    }
}
