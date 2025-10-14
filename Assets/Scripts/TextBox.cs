using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.TextCore.Text;

public class TextBox : MonoBehaviour
{
    // [Header("Prefabs")]
    // [SerializeField] GameObject textWithAvatarGO;
    // TextBox textWithAvatar;

    // [Header("References")]
    // TextMeshProUGUI boxText;
    // TextMeshProUGUI boxName;
    // RawImage boxAvatar; // Image of the character speaking
    // RawImage boxImage; // Image of the textbox (frame)
    // RectTransform boxRectTransform;
    // TextBox instance;
    // Canvas Canvas;

    // // Related to typewriter function, to make the text appear nice
    // [Header("Typing")]
    // [SerializeField] float delayBeforeSpeaking;
    // [SerializeField] float delayAfterSpeaking = 0;
    // [SerializeField] float charDelay = 1;
    // [SerializeField] float basecharDelay = -1;
    // public bool isSpeaking;

    // // Initializes the textbox object
    // void Awake()
    // {
    //     instance = this;
    //     TextBox.ourbox = instance;
    //     boxText = transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
    //     boxName = transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
    //     boxAvatar = transform.Find("Avatar").gameObject.GetComponent<RawImage>();

    //     textWithAvatar = textWithAvatarGO.GetComponentInChildren<TextBox>();
    //     Canvas = FindObjectOfType<Canvas>();

    //     boxImage = GetComponent<RawImage>();
    //     boxRectTransform.offsetMin = Vector2.zero;
    //     boxRectTransform.offsetMax = Vector2.zero;
    //     // ChangeBoxImage(texture);

    //     boxText.maxVisibleCharacters = 0;
    //     boxName.maxVisibleCharacters = 0;
    // }

    // public void TypeWriter(string inputText, string inputName, Texture2D inputAvatar)
    // {
    //     if (isSpeaking)
    //     {
    //         ChangeTextSpeed(10);
    //         return;
    //     }

    //     if (instance != textWithAvatar)
    //     {
    //         Instantiate(textWithAvatarGO, Canvas.transform);
    //         Destroy(this.transform.parent.gameObject);
    //     }
    //     boxText.text = inputText;
    //     boxName.text = inputName;
    //     boxAvatar.texture = inputAvatar;

    //     boxText.maxVisibleCharacters = 0;
    //     boxName.maxVisibleCharacters = boxName.text.Length;

    //     StartCoroutine(TypeWriterTMP());
    //     return;
    // }

    // IEnumerator TypeWriterTMP()
    // {
    //     isSpeaking = true;
    //     yield return new WaitForSeconds(delayBeforeSpeaking); // Delay between name and dialogue showing up
    //     for (int i = 0; i <= boxText.text.Length; i++)
    //     {
    //         boxText.maxVisibleCharacters = i;
    //         yield return new WaitForSeconds(charDelay);
    //     }

    //     yield return new WaitForSeconds(delayAfterSpeaking);

    //     isSpeaking = false;
    //     charDelay = basecharDelay;
    // }

    // public void ChangeBoxImage(Texture2D newTexture) // Changes textbox image to input texture
    // {
    //     boxImage.texture = newTexture;
    // }

    // public void ChangeTextSpeed(float newSpeed = 1) // Multiplies current delay with new speed
    // {
    //     charDelay /= newSpeed;
    // }

    TextMeshProUGUI boxText;
    TextMeshProUGUI boxName;
    RawImage boxAvatar;

    [SerializeField] Texture2D texture;

    void Awake()
    {
        boxText = transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
        boxName = transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
        boxAvatar = transform.Find("Avatar").gameObject.GetComponent<RawImage>();

        // boxText.text = "test";
        // boxName.text = "test";
        // boxAvatar.texture = texture;
    }
    public void DisplayText(string inputText, string inputName, Texture2D inputAvatar)
    {
            boxText.text = inputText;
            boxName.text = inputName;
            boxAvatar.texture = inputAvatar;
    }
}
