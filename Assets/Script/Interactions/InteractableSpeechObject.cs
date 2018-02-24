using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSpeechObject : InteractableBase {

    public int SpeechDataArraySize;
    public SpeechData[] speechData;
    private int index = 0;

    private int arraySize;

    private void Awake()
    {
        speechData = new SpeechData[SpeechDataArraySize];
    }

    public override void OnInteract()
    {
        if (PlayerAttributes.instance.IsGameStateFrozen() == false)
        {
            PlayerAttributes.instance.setFreezeGameState(true);
            SpeechBox.instance.Activate(true);
        }

        if (index <= SpeechDataArraySize)
        {
            DoSpeech();
        }
        else
        {
            SpeechBox.instance.Activate(false);
        }
    }

    private void DoSpeech()
    {
        SpeechBox.instance.ChangeText(speechData[index].text);

        float bubbleHeight = speechData[index++].source.transform.position.x;
    }    
}
    


[System.Serializable]
public class SpeechData
{
    public GameObject source;
    public string text;
}