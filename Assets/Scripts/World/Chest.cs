using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chest : MonoBehaviour
{
    bool isOnChest = false;
    [Header("Properties")]
    [SerializeField] GameObject textPrefab;
    [SerializeField] Texture2D texture;
    [SerializeField] GameObject player;

    [Header("Text")]
    [SerializeField] string boxName;
    [SerializeField] string boxText;

    private GameObject textboxGO;
    private bool isTextVisible = false;
    private Canvas canvas;
    private PlayerProperties playerProperties;
    void OnTriggerEnter2D(Collider2D collision)
    {
        isOnChest = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isOnChest = false;
    }
    void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
    }
    void Start()
    {
        playerProperties = player.GetComponent<PlayerProperties>();
    }
    void Update()
    {
        if (isOnChest && Input.GetButtonDown("Down") && !isTextVisible)
        {
            Debug.Log("pressed circle");
            textboxGO = Instantiate(textPrefab, canvas.transform);
            TextBox textboxScript = textboxGO.GetComponent<TextBox>();
            textboxScript.DisplayText(boxText, boxName, texture);
            playerProperties.hasPistol = true;
            Time.timeScale = 0;
            isTextVisible = true;
        }

        if (isTextVisible && Input.GetButtonDown("Jump"))
        {
            Destroy(textboxGO);
            Time.timeScale = 1;
            playerProperties.pistolSprite.SetActive(true);
            // If want to interact again, uncomment
            // isTextVisible = false;
        }
    }
}
