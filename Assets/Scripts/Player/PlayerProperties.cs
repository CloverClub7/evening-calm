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
    private float playerHealth = 5f;
    private float playerMaxHealth = 10f;

    // Variables for invincibility after taking damage
    private float invincibilityTime = 2f;
    private float invincibilityTimer = 0f;
    private bool isInvincible = false;

    // Rudimentary inventory
    public bool hasPistol = false;
    public GameObject pistolSprite;
    bool hasKey = false;
    int pistolLevel = 1;

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
        Debug.Log("Player health: " + playerHealth);

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
        if (isTextVisible && Input.GetButtonDown("Jump"))
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

    void OnTriggerEnter2D(Collider2D collide)
    {
        GameObject collidedWith = collide.gameObject;

        // When colliding with an enemy, only take damage when not invincible
        if (collidedWith.CompareTag("Enemy") && !isInvincible)
        {
            EnemyClass enemy = collidedWith.GetComponent<EnemyClass>();
            playerHealth -= enemy.enemyDamage;
            Debug.Log("Player health decreased, Playerhealth " + playerHealth);

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
