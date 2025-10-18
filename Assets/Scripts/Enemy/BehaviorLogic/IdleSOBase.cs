using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSOBase : ScriptableObject
{
    protected EnemyClass enemy;
    protected Transform transform;
    protected GameObject gameObject;

    protected Transform playerTransform;

    public virtual void Initialize(GameObject gameObject, EnemyClass enemy)
    {
        this.gameObject = gameObject;
        transform = gameObject.transform;
        this.enemy = enemy;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void DoEnterLogic() { }
    public virtual void DoExitLogic() { }
    public virtual void DoFrameUpdateLogic()
    {
        // Change to chase state if player enters chase trigger
        if (enemy.isChasing)
        {
            enemy.stateMachine.ChangeState(enemy.chaseState);
        }
    }
    public virtual void DoPhysicsLogic() { }
    public virtual void DoAnimationTriggerEventLogic(EnemyClass.AnimationTriggerType triggerType) { }
}
