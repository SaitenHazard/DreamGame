using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSortingComparedToPlayer : MonoBehaviour
{
    private void Update()
    {
        Vector2 playerPosition = PlayerAttributes.instance.getCharacterPosition();

        if(playerPosition.y > gameObject.transform.position.y)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = 300;
        }
        else
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = 100;
        }
    }
}
