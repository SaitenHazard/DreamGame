using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBox : MonoBehaviour {

    public static SpeechBox instance;


    private GameObject Speech;

    [SerializeField]
    private Text m_textBox;
    [SerializeField]
    private GameObject speechBubble;

    private void Awake()
    {
        instance = this;

        Speech = instance.gameObject;

        Show(false);
    }

    public void Show(bool show)
    {
        Speech.SetActive(show);
    }

    public void ChangeText(string text, Vector2 bubblePosition)
    {
        speechBubble.transform.position = bubblePosition;

        m_textBox.text = text;
    }

    public GameObject getSpeechBubbleGameObject()
    {
        return speechBubble;
    }
    
}
