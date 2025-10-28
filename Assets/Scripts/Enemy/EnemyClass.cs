using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// The enemy class
// A lot of states, like the attack and idle states don't do much or are unused
// There were plans to use them but I had to limit them for time and was able to manage without
public class EnemyClass : MonoBehaviour
{
    [Header("Health and Damage")]
    // Damage variables
    public float maxHealth;
    public float enemyDamage;
    private float currentHealth;

    // Movement variables
    public Rigidbody2D rigidBody;
    public bool isFacingRight = true;

    public bool isInWater = false;

    // State machine variables
    public EnemyStateMachine stateMachine;
    public EnemyIdleState idleState;
    public EnemyChaseState chaseState;
    public EnemyAttackState attackState;

    // Trigger check variables
    public bool isInChaseRadius;
    public bool isInAttackRadius;

    // ScriptableObject variables
    [Header("Enemy States")]
    [SerializeField] private IdleSOBase idleBase;
    [SerializeField] private ChaseSOBase chaseBase;
    [SerializeField] private AttackSOBase attackBase;

    public IdleSOBase idleBaseInstance;
    public ChaseSOBase chaseBaseInstance;
    public AttackSOBase attackBaseInstance;

    // Audio clips
    [Header("Audio")]
    [SerializeField] AudioClip damageSound;
    [SerializeField] AudioClip dieSound;


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
        SoundFXManager.instance.PlaySoundClip(damageSound, transform, 1f);
        currentHealth -= damageAmount;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        SoundFXManager.instance.PlaySoundClip(dieSound, transform, 1f);
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

    // Check distance from player
    public void SetChasing(bool isChasing)
    {
        this.isInChaseRadius = isChasing;
    }

    public void SetAttacking(bool isAttacking)
    {
        this.isInAttackRadius = isAttacking;
    }

    // Tracking entering and exiting water
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 4)
        {
            Debug.Log("Enemy in water // " + collision.gameObject.name);
            isInWater = true;
            rigidBody.gravityScale /= 5;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 4)
        {
            isInWater = false;
            rigidBody.gravityScale *= 5;
        }
    }

    virtual public void OnCollisionEnter2D(Collision2D collision) { }
}
