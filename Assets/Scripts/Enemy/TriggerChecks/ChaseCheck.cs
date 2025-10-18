using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCheck : MonoBehaviour
{
    public GameObject player { get; set; }
    private EnemyClass enemy;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GetComponentInParent<EnemyClass>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            enemy.SetChasing(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            enemy.SetChasing(false);
        }
    }
}
