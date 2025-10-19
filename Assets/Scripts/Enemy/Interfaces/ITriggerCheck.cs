using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerCheck
{
    bool isInChaseRadius { get; set; }
    bool isInAttackRadius { get; set; }

    void SetChasing(bool isChasing);

    void SetAttacking(bool isAttacking);
}