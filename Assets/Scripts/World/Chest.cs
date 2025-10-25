using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool isOnChest = false;

    [Header("Properties")]
    [SerializeField] GameObject textPrefab;
    [SerializeField] Texture2D texture;

    [Header("Text")]
    [SerializeField] string boxName;
    [SerializeField] string boxText;

    private GameObject textboxGO;
    private bool isTextVisible = false;
    private Canvas canvas;
    private PlayerProperties playerProperties;

    // Int tracks what the chest gives the player
    // 0: pistol
    // 1: pistol damage upgrade
    // 2: pistol range upgrade
    // 3: increased max health
    // 4: heal to max health

    [Header("Chest Contains")]
    [SerializeField] public int chestItem;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnChest = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isOnChest = false;
    }

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerProperties = player.GetComponent<PlayerProperties>();
        canvas = FindObjectOfType<Canvas>();
    }

    void Update()
    {
        if (isOnChest && Input.GetButtonDown("Down") && !isTextVisible)
        {
            textboxGO = Instantiate(textPrefab, canvas.transform);
            TextBox textboxScript = textboxGO.GetComponent<TextBox>();
            textboxScript.DisplayText(boxText, boxName, texture);

            switch (chestItem)
            {
                case 0:
                    playerProperties.hasPistol = true;
                    playerProperties.pistolSprite.SetActive(true);
                    Debug.Log("Player given a pistol");
                    break;
                case 1:
                    playerProperties.pistolDamageMultiplier = playerProperties.pistolDamageMultiplier * 2;
                    Debug.Log("Player given range upgrade");
                    break;
                case 2:
                    playerProperties.pistolRangeMultiplier = playerProperties.pistolRangeMultiplier * 2;
                    Debug.Log("Player given damage upgrade");
                    break;
                case 3:
                    playerProperties.playerMaxHealth += 5;
                    playerProperties.playerHealth = playerProperties.playerMaxHealth;
                    Debug.Log("Player given health upgrade");
                    break;
                case 4:
                    playerProperties.playerHealth = playerProperties.playerMaxHealth;
                    Debug.Log("Player health restored");
                    break;
                default:
                    Debug.Log("You forgot to put an item in this chest");
                    break;
            }
            
            Time.timeScale = 0;
            isTextVisible = true;
        }

        if (isTextVisible && Input.GetButtonDown("Space"))
        {
            Destroy(textboxGO);
            Time.timeScale = 1;
            if (chestItem != 4)
            {
                Destroy(this.gameObject);
            }
            isTextVisible = false;
        }
    }
}
