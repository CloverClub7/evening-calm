using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "FishIdle", menuName = "Enemy Logic/Idle/Fish Idle")]
public class FishIdle : IdleSOBase
{
    // [SerializeField] private float speed = 2f;
    // private float directionX;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        // directionX = 1;
        rigidbody.gravityScale = 0;
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        // Change to chase state if player enters chase radius
        if (enemy.isInChaseRadius)
        {
            enemy.stateMachine.ChangeState(enemy.chaseState);
        }

        // // Move horizontally in idle state
        // if (enemy.isInWater)
        // {
        //     rigidbody.velocity = new Vector2(directionX * speed, rigidbody.velocity.y);
        //     rigidbody.gravityScale = 0;
        // }
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

