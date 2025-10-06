using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float playerHealth = 5f;
    private float playerMaxHealth = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player health: " + playerHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        GameObject collidedWith = collide.gameObject;
        if (collidedWith.CompareTag("Enemy"))
        {
            EnemyClass enemy = collidedWith.GetComponent<EnemyClass>();
            playerHealth -= enemy.GetDamage();
            Debug.Log("Player health decreased, Playerhealth " + playerHealth);
        }
    }
}
