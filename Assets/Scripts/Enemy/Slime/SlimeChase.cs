using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SlimeChase", menuName = "Enemy Logic/Chase/Slime Chase")]
public class SlimeChase : ChaseSOBase
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

        Debug.Log("Slime is trying to move.");
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        rigidbody.velocity = new Vector2(direction.x * speed, rigidbody.velocity.y);     
    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();
    }

    public override void Initialize(GameObject gameObject, EnemyClass enemy)
    {
        base.Initialize(gameObject, enemy);
    }
}
