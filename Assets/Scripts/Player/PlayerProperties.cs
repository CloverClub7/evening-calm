using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProperties : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    GameObject healthDisplayGO;
    HealthDisplay healthDisplay;

    [Header("Health")]
    public float playerHealth = 5f;
    public float playerMaxHealth = 10f;

    // Variables for invincibility after taking damage
    private float invincibilityTime = 2f;
    private float invincibilityTimer = 0f;
    private bool isInvincible = false;

    // Rudimentary inventory
    [Header("Inventory")]
    public bool hasPistol = false;
    public GameObject pistolSprite;
    public float pistolDamageMultiplier = 1;
    public float pistolRangeMultiplier = 1;

    // Textbox for player death
    [Header("Death Textbox")]
    [SerializeField] GameObject textPrefab;
    [SerializeField] Texture2D texture;
    private string boxName = " ";
    public string boxText = "You have died. Close the text box to respawn.";
    private Canvas canvas;
    private GameObject textboxGO;
    private bool isTextVisible = false;


    void Start()
    {
        healthDisplayGO = GameObject.Find("HealthDisplayTMP");
        healthDisplay = healthDisplayGO.GetComponent<HealthDisplay>();

        canvas = GameObject.FindObjectOfType<Canvas>();

        pistolSprite = GameObject.Find("Pistol");
        pistolSprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Fire the pistol if it is in inventory
        if (hasPistol && Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);
        }
        healthDisplay.health = playerHealth;

        // Reload the scene (restart) when the death textbox is showing
        if (isTextVisible && Input.GetButtonDown("Space"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("SampleScene");
        }       

        // Timer for invincibility
        if (isInvincible)
        {
            invincibilityTimer += Time.deltaTime;
            if (invincibilityTimer > invincibilityTime)
            {
                isInvincible = false;
                invincibilityTimer = 0;
            }
        } 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidedWith = collision.gameObject;

        // When colliding with an enemy, only take damage when not invincible
        if (collidedWith.CompareTag("Enemy") && !isInvincible)
        {
            EnemyClass enemy = collidedWith.GetComponent<EnemyClass>();
            playerHealth -= enemy.enemyDamage;

            if (playerHealth < 1)
            {
                playerDie();
            }

            isInvincible = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedWith = collision.gameObject;

        // When colliding with a spike, take damage when not invincible
        if (collidedWith.CompareTag("DangerousObject") && !isInvincible)
        {
            Spike spike = collidedWith.GetComponent<Spike>();
            playerHealth -= spike.Damage;

            if (playerHealth < 1)
            {
                playerDie();
            }

            isInvincible = true;
        }
    }

    void playerDie()
    {
        textboxGO = Instantiate(textPrefab, canvas.transform);
        TextBox textboxScript = textboxGO.GetComponent<TextBox>();
        textboxScript.DisplayText(boxText, boxName, texture);
        Time.timeScale = 0;
        isTextVisible = true;
    }
}
