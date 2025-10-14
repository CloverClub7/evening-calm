using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    bool isOnButton = false;
    [SerializeField] GameObject textPrefab;
    [SerializeField] Texture2D texture;
    private GameObject textboxGO;
    private bool isTextVisible = false;
    private Canvas canvas;
    void OnTriggerEnter2D(Collider2D collision)
    {
        isOnButton = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isOnButton = false;
    }
    
    void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
    }
    void Update()
    {
        if (isOnButton && Input.GetButtonDown("Down") && !isTextVisible)
        {
            Debug.Log("pressed circle");
            textboxGO = Instantiate<GameObject>(textPrefab, canvas.transform);
            TextBox textboxScript = textboxGO.GetComponent<TextBox>();
            textboxScript.DisplayText("This is a test of the text.", "Test Name", texture);
            Time.timeScale = 0;
            isTextVisible = true;
        }

        if (isTextVisible && Input.GetButtonDown("Jump"))
        {
            Destroy(textboxGO);
            Time.timeScale = 1;
            // If want to interact again, uncomment
            // isTextVisible = false;
        }
    }
}
