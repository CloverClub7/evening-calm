using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FishCase", menuName = "Enemy Logic/Chase/Fish Chase")]
public class FishChase : ChaseSOBase
{
    [SerializeField] private float speed = 2f;
    private float chaseTimer = 0f;
    private float endChaseTime = 5f;
    

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

        // Move towards player if the fish is still in water
        if (enemy.isInWater)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            rigidbody.velocity = new Vector2(direction.x * speed, direction.y * speed);
            rigidbody.gravityScale = 0;
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

        // Flip the fish if needed
        enemy.Flip(rigidbody.velocity);

    }

    public override void Initialize(GameObject gameObject, EnemyClass enemy)
    {
        base.Initialize(gameObject, enemy);
    }
}
