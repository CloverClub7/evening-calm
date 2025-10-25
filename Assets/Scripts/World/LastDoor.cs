using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDoor : MonoBehaviour
{
    private bool isOnButton = false;
    private bool openDoor = false;

    [SerializeField] GameObject textPrefab;
    [SerializeField] Texture2D texture;    

    [Header("Text")]
    [SerializeField] string boxName;
    [SerializeField] string boxTextFalse;
    [SerializeField] string boxTextTrue;

    [Header("Linked Check Var")]
    [SerializeField] GameObject toCheck;
    private Check2Text checkThis;

    private GameObject textboxGO;
    private bool isTextVisible = false;
    private Canvas canvas;

    [Header("Attached Door")]
    [SerializeField] GameObject door;
    Transform doorTransform;
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
        checkThis = toCheck.GetComponent<Check2Text>();

        doorTransform = door.GetComponent<Transform>();
    }

    void Update()
    {
        if (isOnButton && Input.GetButtonDown("Down") && !isTextVisible)
        {
            textboxGO = Instantiate(textPrefab, canvas.transform);
            TextBox textboxScript = textboxGO.GetComponent<TextBox>();

            if (checkThis.isOn)
            {
                textboxScript.DisplayText(boxTextTrue, boxName, texture);
                openDoor = true;
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

    void FixedUpdate()
    {
        if (openDoor)
        {
            doorTransform.Translate(0, 0.2f, 0);
        }
    }
}
