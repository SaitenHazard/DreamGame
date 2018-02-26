using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBox : MonoBehaviour {

    public static SpeechBox instance;

    public GameObject speechBubble;

    private Image m_DialogFrame;
    private Text m_Text;

    private void Awake()
    {
        instance = this;

        m_DialogFrame = GetComponent<Image>();
        m_Text = GetComponentInChildren<Text>();

        Show(false);
    }

    public void Show(bool show)
    {
        m_DialogFrame.enabled = show;
        m_Text.enabled = show;
    }

    public void ChangeText(string text)
    {
        m_Text.text = text;
    }

    public GameObject getSpeechBubbleGameObject()
    {
        return speechBubble;
    }
    
}
