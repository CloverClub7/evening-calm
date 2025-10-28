using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawns the boss and manages the door
public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject bossPrefab;
    [SerializeField] GameObject door; // The door to the boss room
    public bool isBossActive = false;
    private GameObject bossItself;

    public void SpawnBoss()
    {
        // Spawn the boss
        bossItself = Instantiate(bossPrefab, transform);
        isBossActive = true;

        // Disable the door so the player can't just leave
        door.SetActive(false);
    }

    public void BossDead()
    {
        // Reactivate the door
        door.SetActive(true);
    }

    public void FixedUpdate()
    {
        // If the boss is dead dead, call the appropriate function
        if (isBossActive && bossItself == null)
        {
            BossDead();
        }
    }
}
