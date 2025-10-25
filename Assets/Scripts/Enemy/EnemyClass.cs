using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyClass : MonoBehaviour, IEnemyMovement, ITriggerCheck//, IEnemyDamage
{
    [Header("Health and Damage")]
    // Damage variables
    public float maxHealth;
    public float enemyDamage;
    private float currentHealth;

    // Movement variables
    public Rigidbody2D rigidBody { get; set; }
    public bool isFacingRight { get; set; }

    // State machine variables
    public EnemyStateMachine stateMachine { get; set; }
    public EnemyIdleState idleState { get; set; }
    public EnemyChaseState chaseState { get; set; }
    public EnemyAttackState attackState { get; set; }

    // Trigger check variables
    public bool isInChaseRadius { get; set; }
    public bool isInAttackRadius { get; set; }

    // ScriptableObject variables
    [Header("Enemy States")]
    [SerializeField] private IdleSOBase idleBase;
    [SerializeField] private ChaseSOBase chaseBase;
    [SerializeField] private AttackSOBase attackBase;

    public IdleSOBase idleBaseInstance { get; set; }
    public ChaseSOBase chaseBaseInstance { get; set; }
    public AttackSOBase attackBaseInstance { get; set; }


    private void Awake()
    {
        currentHealth = maxHealth;
        rigidBody = GetComponent<Rigidbody2D>();

        // Create instances of state classes for each enemy
        idleBaseInstance = Instantiate(idleBase);
        chaseBaseInstance = Instantiate(chaseBase);
        attackBaseInstance = Instantiate(attackBase);

        stateMachine = new EnemyStateMachine();

        idleState = new EnemyIdleState(this, stateMachine);
        chaseState = new EnemyChaseState(this, stateMachine);
        attackState = new EnemyAttackState(this, stateMachine);

        idleBaseInstance.Initialize(gameObject, this);
        chaseBaseInstance.Initialize(gameObject, this);
        attackBaseInstance.Initialize(gameObject, this);

        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentEnemyState.FrameUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.currentEnemyState.PhysicsUpdate();
    }

    // Damage functions
    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    // Movement functions
    public void MoveEnemy(Vector2 velocity)
    {

    }

    // Flip direction if needed
    public void Flip(Vector2 velocity)
    {
        if (isFacingRight && velocity.x < 0f || !isFacingRight && velocity.x > 0)
        {
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    // State machine functions
    public enum AnimationTriggerType
    {
        EnemyDamaged
    }

    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        stateMachine.currentEnemyState.AnimationTriggerEvent(triggerType);
    }

    // Check distance from player
    public void SetChasing(bool isChasing)
    {
        this.isInChaseRadius = isChasing;
    }

    public void SetAttacking(bool isAttacking)
    {
        this.isInAttackRadius = isAttacking;
    }

}
