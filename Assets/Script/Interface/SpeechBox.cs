using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBox : MonoBehaviour {

    public static SpeechBox instance;

    public GameObject speechBubble;

    private GameObject Speechbox;
    private Text m_text;

    private void Awake()
    {
        instance = this;
        Speechbox = gameObject;
        m_text = Speechbox.GetComponent<Text>();
    }

    public void Activate(bool activate)
    {
        Speechbox.SetActive(activate);
    }

    public void ChangeText(string text)
    {
        m_text.text = text;
    }

    public GameObject getSpeechBubbleGameObject()
    {
        return speechBubble;
    }
    
}
