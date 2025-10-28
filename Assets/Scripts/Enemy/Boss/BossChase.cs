using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossChase", menuName = "Enemy Logic/Chase/Boss Chase")]
public class BossChase : ChaseSOBase
{
    [SerializeField] private float speed = 1f;
    [SerializeField] GameObject projectilePrefab;
    public float shootInterval = 20f;
    private float shootTimer = 0;

    // Projectile variables
    public float radius = 1.5f;
    public float projectileSpeed = 10f;

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

        shootTimer += Time.deltaTime;

        if (shootTimer > shootInterval)
        {
            shootTimer = 0;

            // Spawn projectiles
            for (int i = 0; i < 8; i++)
            {
                float angle = i * (360f / 8);
                Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

                Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y);

                GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

                projectile.GetComponent<Rigidbody2D>().gravityScale = 0;
                projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
            }
        }
    }

    public override void DoPhysicsLogic()
    {
        
        base.DoPhysicsLogic();

        // Move towards player
        Vector2 direction = (playerTransform.position - transform.position).normalized;

        if (enemy.isInWater)
        {
            rigidbody.velocity = new Vector2(direction.x * speed, direction.y * speed);
            rigidbody.gravityScale = 0;
        }
        else
        {
            rigidbody.velocity = new Vector2(direction.x * speed, rigidbody.velocity.y);
            rigidbody.gravityScale = 1;
        }

        // Flip if needed
        enemy.Flip(rigidbody.velocity);
    }

    public override void Initialize(GameObject gameObject, EnemyClass enemy)
    {
        base.Initialize(gameObject, enemy);
    }
}
