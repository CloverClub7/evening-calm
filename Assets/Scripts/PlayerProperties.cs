using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    private float playerHealth = 5f;
    private float playerMaxHealth = 5f;

    // Rudimentary inventory
    bool hasPistol = false;
    bool hasKey = false;
    int pistolLevel = 1;


    void Start()
    {
        Debug.Log("Player health: " + playerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // Fire the pistol if it is in inventory
        if (hasPistol && Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate<GameObject>(bulletPrefab);
            bullet.transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);
        }
    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        GameObject collidedWith = collide.gameObject;

        // When colliding with an enemy
        if (collidedWith.CompareTag("Enemy"))
        {
            EnemyClass enemy = collidedWith.GetComponent<EnemyClass>();
            playerHealth -= enemy.GetDamage();
            Debug.Log("Player health decreased, Playerhealth " + playerHealth);
        }
    }
}
