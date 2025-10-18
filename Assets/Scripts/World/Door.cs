using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Link two doors together and allow the player to teleport between the two
public class Door : MonoBehaviour
{
    [Header("Linked Door")]
    [SerializeField] GameObject linkedDoor;
    
    private GameObject player;
    private bool isOnDoor;

    void Awake()
    {
        isOnDoor = false;
        player = GameObject.FindWithTag("Player");
    } 

    // Detect if the player is within a door
    void OnTriggerEnter2D(Collider2D collision)
    {
        isOnDoor = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isOnDoor = false;
    }
    void Update()
    {
        if (isOnDoor && Input.GetButtonDown("Down"))
        {
            player.transform.position = linkedDoor.transform.position;
        }
    }
}
