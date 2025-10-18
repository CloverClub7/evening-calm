using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMovement
{
    Rigidbody2D rigidBody { get; set; }
    bool isFacingRight { get; set; }
    void MoveEnemy(Vector2 velocity);
    void Flip(Vector2 velocity);
}
