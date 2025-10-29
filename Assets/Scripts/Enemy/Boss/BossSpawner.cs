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
    private AudioSource audioSource;
    [SerializeField] AudioClip bossMusic;

    public void SpawnBoss()
    {
        // Spawn the boss
        bossItself = Instantiate(bossPrefab, transform);
        isBossActive = true;

        // Play the music
        audioSource.clip = bossMusic;
        audioSource.volume = 0.1f;
        audioSource.Play();

        // Disable the door so the player can't just leave
        door.SetActive(false);
    }

    public void BossDead()
    {
        // Stop the music
        audioSource.Stop();

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

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
