using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributes : MonoBehaviour {

    public CharacterBaseControl baseControl;
    public CharacterMovementModel movementModel;

    public float speed;
    public float bubbleSpeechHeight;

    protected void Awake()
    {
        baseControl = gameObject.GetComponent<CharacterBaseControl>();
        movementModel = gameObject.GetComponent<CharacterMovementModel>();
    }

    public float getSpeed()
    {
        return speed;
    }

    public float getBubbleSpeechHeight()
    {
        return bubbleSpeechHeight;
    }

    public Vector2 getCharacterPosition()
    {
        Vector2 positon = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

        return positon;
    }

    public void SetDirection(Vector2 direction)
    {
        baseControl.SetDirection(direction);
    }
}
