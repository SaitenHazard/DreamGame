using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public enum facingDirection
{
    Null,
    Up,
    Down,
    Left,
    Right
}

public class InteractableSpeechObject : InteractableBase {

    public facingDirection defaultDirection = facingDirection.Null;
    public SpeechData[] speechData;

    public int index;

    private int arraySize;
    private CharacterAttributes attributes;

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
            SetSelfDefaultDirection();

            PlayerAttributes.instance.setFreezeGameState(false);
            SpeechBox.instance.Show(false);
        }
    }

    private void SetSelfDefaultDirection()
    {
        if(defaultDirection != facingDirection.Null)
            SetDirection(defaultDirection);
    }

    private void DoSpeech()
    {
        attributes = speechData[index].source.GetComponent<CharacterAttributes>();

        Vector2 sourcePosition = attributes.getCharacterPosition();
        Vector2 bubblePosition = new Vector2(sourcePosition.x, sourcePosition.y + attributes.getBubbleSpeechHeight());
        Vector2 bubblePositionToScreen = Camera.main.WorldToScreenPoint(bubblePosition);
            
        SpeechBox.instance.ChangeText(speechData[index].text, bubblePosition);

        SetDirection(facingDirection.Null);

        index++;
    }

    private void SetDirection(facingDirection direction)
    {
        Vector2 vector2Direction = Vector2.zero;

        if (direction == facingDirection.Null)
        {
            Vector2 temp = PlayerAttributes.instance.movementModel.GetFacingDirection();

            if (temp.x == 1) direction = facingDirection.Left;
            else if (temp.x == -1) direction = facingDirection.Right;
            else if (temp.y == -1) direction = facingDirection.Up;
            else direction = facingDirection.Down;
        }

        if (direction == facingDirection.Up)
            vector2Direction = Vector2.up;
        else if (direction == facingDirection.Down)
            vector2Direction = Vector2.down;
        else if (direction == facingDirection.Left)
            vector2Direction = Vector2.left;
        else vector2Direction = Vector2.right;

        gameObject.GetComponent<CharacterAttributes>().SetDirection(vector2Direction);
    }
}
    


[System.Serializable]
public class SpeechData
{
    public GameObject source;
    public string text;
}