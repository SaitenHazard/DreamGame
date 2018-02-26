using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSpeechObject : InteractableBase {

    public SpeechData[] speechData;

    private int index;
    private int arraySize;
    private GameObject bubbleSpeech;

    private void Awake()
    {
    }

    public override void OnInteract()
    {
        if (PlayerAttributes.instance.IsGameStateFrozen() == false)
        {
            index = 0;
            PlayerAttributes.instance.setFreezeGameState(true);
            SpeechBox.instance.Show(true);
        }

        if (index < speechData.Length)
        {
            DoSpeech();
        }
        else
        {
            DestroyImmediate(bubbleSpeech);
            PlayerAttributes.instance.setFreezeGameState(false);
            SpeechBox.instance.Show(false);

        }
    }

    private void DoSpeech()
    {
        CharacterAttributes attributes = speechData[index].source.GetComponent<CharacterAttributes>();

        Vector2 sourcePosition = attributes.getCharacterPosition();
        Vector2 bubblePosition = new Vector2(sourcePosition.x, sourcePosition.y + attributes.getBubbleSpeechHeight());

        bubbleSpeech = SpeechBox.instance.getSpeechBubbleGameObject();

        bubbleSpeech.transform.position = bubblePosition;
            
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