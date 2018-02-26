using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSpeechObject : InteractableBase {

    public int SpeechDataArraySize;
    public SpeechData[] speechData;

    private int index = 0;
    private int arraySize;
    private GameObject bubbleSpeech;

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
            PlayerAttributes.instance.setFreezeGameState(false);
            SpeechBox.instance.Activate(false);
        }
    }

    private void DoSpeech()
    {
        Vector2 sourcePosition = speechData[index].source.GetComponent<CharacterAttributes>().getCharacterPosition();
        Vector2 bubblePosition = new Vector2(sourcePosition.x, sourcePosition.y + speechData[index].source.GetComponent<CharacterAttributes>().getBubbleSpeechHeight());

        if (bubbleSpeech == null)
        {
            bubbleSpeech = SpeechBox.instance.getSpeechBubbleGameObject();
            Instantiate(bubbleSpeech, bubblePosition, Quaternion.identity);
        }
        else
        {
            bubbleSpeech.transform.position = bubblePosition;
        }
            
        SpeechBox.instance.ChangeText(speechData[index].text);
        index++;
    }    
}
    


[System.Serializable]
public class SpeechData
{
    public GameObject source;
    public string text;
}