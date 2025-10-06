using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    // private float height = 0f;
    // private float targetY = 0f;
    // private float targetX = 0f;
    // private float speed = 1f;
    private float vertical;
    void LateUpdate()
    {
        vertical = Input.GetAxisRaw("Vertical");

        // Vector3 targetDirection = new Vector3(player.position.x, targetY - transform.position.y, transform.position.z);

        // targetDirection.Normalize();

        transform.position = new Vector3(player.position.x, player.position.y + vertical * 2f, transform.position.z);
    }
}
