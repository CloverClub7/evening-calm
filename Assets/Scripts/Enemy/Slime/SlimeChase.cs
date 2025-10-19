using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SlimeChase", menuName = "Enemy Logic/Chase/Slime Chase")]
public class SlimeChase : ChaseSOBase
{
    [SerializeField] private float speed = 1f;
    private float jumpingPower = 5f;
    private LayerMask groundLayer;
    private float timeBetweenJumps = 2f;
    private float jumpTimer;
    private float chaseTimer = 0f;
    private float endChaseTime = 5f;
    

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

        // Jump towards player
        if (isGrounded() && jumpTimer > timeBetweenJumps)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            rigidbody.velocity = new Vector2(direction.x * speed, jumpingPower);

            jumpTimer = 0f;
        }

        // If the player is out of the chase radius for a while, go back to idle state
        if (!enemy.isInChaseRadius)
        {
            chaseTimer += Time.deltaTime;
        }
        else
        {
            chaseTimer = 0f;
        }
        if (chaseTimer > endChaseTime)
        {
            enemy.stateMachine.ChangeState(enemy.idleState);
        }

        jumpTimer += Time.deltaTime;
    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();
    }

    public override void Initialize(GameObject gameObject, EnemyClass enemy)
    {
        base.Initialize(gameObject, enemy);

        groundLayer = LayerMask.GetMask("Ground");
        jumpTimer = timeBetweenJumps;
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, 0.3f, groundLayer);
    }
}
