using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    private float health = 6f;

    // Block breaks when it's health reaches zero
    void Update()
    {
        if (health < 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Take damage when hit by bullet
    public void Damage(float damage)
    {
        health -= damage;
    }
}
