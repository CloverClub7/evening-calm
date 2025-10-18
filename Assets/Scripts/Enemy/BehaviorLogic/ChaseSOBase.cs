using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseSOBase : ScriptableObject
{
    protected EnemyClass enemy;
    protected Transform transform;
    protected GameObject gameObject;
    protected Rigidbody2D rigidbody;

    protected Transform playerTransform;

    public virtual void Initialize(GameObject gameObject, EnemyClass enemy)
    {
        this.gameObject = gameObject;
        transform = gameObject.transform;
        this.enemy = enemy;

        rigidbody = gameObject.GetComponent<Rigidbody2D>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void DoEnterLogic() { }
    public virtual void DoExitLogic() { }
    public virtual void DoFrameUpdateLogic() { }
    public virtual void DoPhysicsLogic() { }
    public virtual void DoAnimationTriggerEventLogic(EnemyClass.AnimationTriggerType triggerType) { }
}
