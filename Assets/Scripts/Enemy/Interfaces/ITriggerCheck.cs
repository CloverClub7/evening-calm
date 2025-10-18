using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerCheck
{
    bool isChasing { get; set; }
    bool isAttacking { get; set; }

    void SetChasing(bool isChasing);

    void SetAttacking(bool isAttacking);
}