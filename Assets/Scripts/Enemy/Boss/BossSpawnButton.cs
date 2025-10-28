using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawns the boss when the player interacts with the terminal, then destroys itself
// and lets the boss spawner & boss handle the rest
public class BossSpawnButton : MonoBehaviour
{
    [SerializeField] GameObject bossSpawnerGO;
    private bool isOnButton;
    private BossSpawner bossSpawner;

    // This will be like a button hiding behind the terminal in the boss room
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            isOnButton = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        isOnButton = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Down") && isOnButton)
        {
            bossSpawner.SpawnBoss();
            Destroy(this);
        }
    }
    void Start()
    {
        bossSpawner = bossSpawnerGO.GetComponent<BossSpawner>();
    }
}

