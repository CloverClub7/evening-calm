using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IEnemyDamage
{
    [SerializeField] float maxHealth { get; set; }
    [SerializeField] float enemyDamage { get; set;}
    float currentHealth { get; set;}
    void Damage(float damageAmount);
    void Die();
}