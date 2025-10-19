using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SlimeIdle", menuName = "Enemy Logic/Idle/Slime Idle")]
public class SlimeIdle : IdleSOBase
{
    [SerializeField] private float speed = 1f;
    public override void DoAnimationTriggerEventLogic(EnemyClass.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();

        // Change to chase state if player enters chase radius
        if (enemy.isInChaseRadius)
        {
            enemy.stateMachine.ChangeState(enemy.chaseState);
        }
    }

    public override void Initialize(GameObject gameObject, EnemyClass enemy)
    {
        base.Initialize(gameObject, enemy);
    }
}
