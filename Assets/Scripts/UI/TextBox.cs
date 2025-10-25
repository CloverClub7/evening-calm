using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.TextCore.Text;

public class TextBox : MonoBehaviour
{
    TextMeshProUGUI boxText;
    TextMeshProUGUI boxName;
    RawImage boxAvatar;

    [SerializeField] Texture2D texture;

    void Awake()
    {
        boxText = transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
        boxName = transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
        boxAvatar = transform.Find("Avatar").gameObject.GetComponent<RawImage>();
    }
    public void DisplayText(string inputText, string inputName, Texture2D inputAvatar)
    {
            boxText.text = inputText;
            boxName.text = inputName;
            boxAvatar.texture = inputAvatar;
    }
}
