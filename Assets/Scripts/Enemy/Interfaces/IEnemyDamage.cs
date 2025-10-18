using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IEnemyDamage
{
    float maxHealth { get;  set;}
    float currentHealth { get; set;}
    float enemyDamage { get; set;}

    void Damage(float damageAmount);

    void Die();
}