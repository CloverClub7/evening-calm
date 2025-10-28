using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Blocks that can be broken by the player
public class BreakableBlock : MonoBehaviour
{
    private float health = 6f;
    [SerializeField] AudioClip breakSound;

    // Block breaks when it's health reaches zero
    void Update()
    {
        if (health < 1)
        {
            SoundFXManager.instance.PlaySoundClip(breakSound, transform, 1f);
            Destroy(this.gameObject);
        }
    }

    // Take damage when hit by bullet
    public void Damage(float damage)
    {
        health -= damage;
    }
}
