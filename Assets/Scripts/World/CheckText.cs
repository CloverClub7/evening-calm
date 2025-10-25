using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckText : MonoBehaviour
{
    private bool isOnButton = false;

    [SerializeField] GameObject textPrefab;
    [SerializeField] Texture2D texture;    

    [Header("Text")]
    [SerializeField] string boxName;
    [SerializeField] string boxTextFalse;
    [SerializeField] string boxTextTrue;

    [Header("Linked Check Var")]
    [SerializeField] GameObject toCheck;
    private VarText varText;

    private GameObject textboxGO;
    private bool isTextVisible = false;
    private Canvas canvas;    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOnButton = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isOnButton = false;
    }

    void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        varText = toCheck.GetComponent<VarText>();
    }

    void Update()
    {
        if (isOnButton && Input.GetButtonDown("Down") && !isTextVisible)
        {
            textboxGO = Instantiate(textPrefab, canvas.transform);
            TextBox textboxScript = textboxGO.GetComponent<TextBox>();

            if (varText.isOperating)
            {
                textboxScript.DisplayText(boxTextTrue, boxName, texture);
            }
            else
            {
                textboxScript.DisplayText(boxTextFalse, boxName, texture);
            }
            Time.timeScale = 0;
            isTextVisible = true;
        }

        if (isTextVisible && Input.GetButtonDown("Space"))
        {
            Destroy(textboxGO);
            Time.timeScale = 1;
            isTextVisible = false;
        }
    }
}
